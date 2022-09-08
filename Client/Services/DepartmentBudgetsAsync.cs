using Shared.Models.Departments;
using Shared.Wrappers;

using System.Collections.Generic;
using System.Threading.Tasks;


namespace Client.Services
{
    public interface IDepartmentBudgetsServiceAsync
    {
         Task<Response<DepartmentBudgetsResponse>> GetByIdAsync(int id);
        Task<Response<List<DepartmentBudgetsResponse>>> GetAllAsync();
        Task<Response<int>> SaveAsync(AddEditDepartmentBudgets model);
        Task<Response<int>> DeleteAsync(int id);
    }
    public class DepartmentBudgetsServiceAsync : IDepartmentBudgetsServiceAsync
    {
        private IHttpService _httpService;
        public DepartmentBudgetsServiceAsync(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<Response<int>> DeleteAsync(int Id)
        {
            return await _httpService.Delete<Response<int>>($"v1/DepartmentBudgets/{Id}");
        }

        public async Task<Response<List<DepartmentBudgetsResponse>>> GetAllAsync()
        {
            return await _httpService.Get<Response<List<DepartmentBudgetsResponse>>>("v1/DepartmentBudgets");
        }

        public async Task<Response<DepartmentBudgetsResponse>> GetByIdAsync(int Id)
        {
            return await _httpService.Get<Response<DepartmentBudgetsResponse>>($"v1/DepartmentBudgets/{Id}");
        }

        public async Task<Response<int>> SaveAsync(AddEditDepartmentBudgets model)
        {
            try
            {
                return await _httpService.Post<Response<int>>("v1/DepartmentBudgets", model);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }

   
}
