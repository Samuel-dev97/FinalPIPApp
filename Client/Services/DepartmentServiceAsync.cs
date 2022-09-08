using Shared.Models.Departments;
using Shared.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Services
{
    public interface IDepartmentServiceAsync
    {
        Task<Response<DepartmentsResponse>> GetByIdAsync(int id);
        Task<Response<List<DepartmentsResponse>>> GetAllAsync();
        Task<Response<int>> SaveAsync(AddEditDepartments model);
        Task<Response<int>> DeleteAsync(int id);
    }
    public class DepartmentServiceAsync : IDepartmentServiceAsync
    {
        private IHttpService _httpService;
        public DepartmentServiceAsync(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<Response<int>> DeleteAsync(int Id)
        {
            return await _httpService.Delete<Response<int>>($"v1/Departments/{Id}");
        }

        public async Task<Response<List<DepartmentsResponse>>> GetAllAsync()
        {
            return await _httpService.Get<Response<List<DepartmentsResponse>>>("v1/Departments");
        }

        public async Task<Response<DepartmentsResponse>> GetByIdAsync(int Id)
        {
            return await _httpService.Get<Response<DepartmentsResponse>>($"v1/Departments/{Id}");
        }

        public async Task<Response<int>> SaveAsync(AddEditDepartments model)
        {
            try
            {
                return await _httpService.Post<Response<int>>("v1/Departments", model);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
