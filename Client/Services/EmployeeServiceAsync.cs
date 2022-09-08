using Shared.Models.Employee;
using Shared.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Services
{
    public interface IEmployeeServiceAsync
    {
        Task<Response<EmployeeResponse>> GetByIdAsync(int id);
        Task<Response<List<EmployeeResponse>>> GetAllAsync();
        Task<Response<int>> SaveAsync(AddEditEmployee model);
        Task<Response<int>> DeleteAsync(int id);
    }
    public class EmployeeServiceAsync : IEmployeeServiceAsync
    {
        private IHttpService _httpService;
        public EmployeeServiceAsync(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<Response<int>> DeleteAsync(int Id)
        {
            return await _httpService.Delete<Response<int>>($"v1/Employees/{Id}");
        }

        public async Task<Response<List<EmployeeResponse>>> GetAllAsync()
        {
            return await _httpService.Get<Response<List<EmployeeResponse>>>("v1/Employees");
        }

        public async Task<Response<EmployeeResponse>> GetByIdAsync(int Id)
        {
            return await _httpService.Get<Response<EmployeeResponse>>($"v1/Employees/{Id}");
        }

        public async Task<Response<int>> SaveAsync(AddEditEmployee model)
        {
            try
            {
                return await _httpService.Post<Response<int>>("v1/Employees", model);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
