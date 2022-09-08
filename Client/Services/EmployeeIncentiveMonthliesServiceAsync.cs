using Shared.Models.EmployeeIncentiveMonthlies;
using Shared.Models.PayGrades;
using Shared.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Client.Services
{
    public interface IEmployeeIncentiveMonthliesServiceAsync
    {
        Task<Response<EmployeeIncentiveMonthliesResponse>> GetByIdAsync(int id);
        Task<Response<List<EmployeeIncentiveMonthliesResponse>>> GetAllAsync();
        Task<Response<int>> SaveAsync(AddEditEmployeeIncentiveMonthlies model);
        Task<Response<int>> DeleteAsync(int id);
    }
    public class EmployeeIncentiveMonthliesServiceAsync : IEmployeeIncentiveMonthliesServiceAsync
    {
        private IHttpService _httpService;
        public EmployeeIncentiveMonthliesServiceAsync(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<Response<int>> DeleteAsync(int Id)
        {
            return await _httpService.Delete<Response<int>>($"v1/EmployeeIncentivesMonthlies/{Id}");
        }

        public async Task<Response<List<EmployeeIncentiveMonthliesResponse>>> GetAllAsync()
        {
            return await _httpService.Get<Response<List<EmployeeIncentiveMonthliesResponse>>>("v1/EmployeeIncentivesMonthlies");
        }

        public async Task<Response<EmployeeIncentiveMonthliesResponse>> GetByIdAsync(int Id)
        {
            return await _httpService.Get<Response<EmployeeIncentiveMonthliesResponse>>($"v1/EmployeeIncentivesMonthlies/{Id}");
        }

        public async Task<Response<int>> SaveAsync(AddEditEmployeeIncentiveMonthlies model)
        {
            try
            {
                return await _httpService.Post<Response<int>>("v1/EmployeeIncentivesMonthlies", model);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
