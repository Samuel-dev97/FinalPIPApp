using Shared.Models.EmployeeIncetives;
using Shared.Models.PayGrades;
using Shared.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Client.Services
{

    public interface IEmployeeIncentivesServiceAsync
    {
        Task<Response<EmployeeIncentivesResponse>> GetByIdAsync(int id);
        Task<Response<List<EmployeeIncentivesResponse>>> GetAllAsync();
        Task<Response<int>> SaveAsync(AddEditEmployeeIncentives model);
        Task<Response<int>> DeleteAsync(int Id);
        Task<Response<int>> DeleteAllAsync();
        //Task<Response<List> DeleteAllAsync();
    }
    public class EmployeeIncentivesServiceAsync : IEmployeeIncentivesServiceAsync
    {
        private IHttpService _httpService;
        public EmployeeIncentivesServiceAsync(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<Response<int>> DeleteAsync(int Id)
        {
            return await _httpService.Delete<Response<int>>($"v1/EmployeeIncentives/{Id}");
        }
        public async Task<Response<int>> DeleteAllAsync()
        {
            return await _httpService.Delete<Response<int>>($"v1/EmployeeIncentives/all");
        }

        public async Task<Response<List<EmployeeIncentivesResponse>>> GetAllAsync()
        {
            return await _httpService.Get<Response<List<EmployeeIncentivesResponse>>>("v1/EmployeeIncentives");
        }

        public async Task<Response<EmployeeIncentivesResponse>> GetByIdAsync(int Id)
        {
            return await _httpService.Get<Response<EmployeeIncentivesResponse>>($"v1/EmployeeIncentives/{Id}");
        }
         
        public async Task<Response<int>> SaveAsync(AddEditEmployeeIncentives model)
        {
            try
            {
                return await _httpService.Post<Response<int>>("v1/EmployeeIncentives", model);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

       
    }
}
