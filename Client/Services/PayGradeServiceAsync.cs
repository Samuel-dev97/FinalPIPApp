using Shared.Models.PayGrades;
using Shared.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Client.Services
{
    public interface IPayGradeServiceAsync
    {
        Task<Response<PayGradeResponse>> GetByIdAsync(int id);
        Task<Response<List<PayGradeResponse>>> GetAllAsync();
        Task<Response<int>> SaveAsync(AddEditPayGrade model);
        Task<Response<int>> DeleteAsync(int id);
    }
    public class PayGradeServiceAsync : IPayGradeServiceAsync
    {
        private IHttpService _httpService;
        public PayGradeServiceAsync(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<Response<int>> DeleteAsync(int Id)
        {
            return await _httpService.Delete<Response<int>>($"v1/PayGrade/{Id}");
        }

        public async Task<Response<List<PayGradeResponse>>> GetAllAsync()
        {
            return await _httpService.Get<Response<List<PayGradeResponse>>>("v1/PayGrade");
        }

        public async Task<Response<PayGradeResponse>> GetByIdAsync(int Id)
        {
            return await _httpService.Get<Response<PayGradeResponse>>($"v1/PayGrade/{Id}");
        }

        public async Task<Response<int>> SaveAsync(AddEditPayGrade model)
        {
            try
            {
                return await _httpService.Post<Response<int>>("v1/PayGrade", model);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
