using Client.Models;
using Shared.Models.Penalties;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Services
{
    public interface IPenaltiesServiceAsync
    {
        Task<Response<PenaltiesResponse>> GetByIdAsync(int id);
        Task<Response<List<PenaltiesResponse>>> GetAllAsync();
        Task<Response<int>> SaveAsync(AddEditPenalties model);
        Task<Response<int>> DeleteAsync(int id);
    }
    public class PenaltiesServiceAsync : IPenaltiesServiceAsync
    {
        private IHttpService _httpService;
        public PenaltiesServiceAsync(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<Response<int>> DeleteAsync(int Id)
        {
            return await _httpService.Delete<Response<int>>($"v1/Penalties/{Id}");
        }

        public async Task<Response<List<PenaltiesResponse>>> GetAllAsync()
        {
            return await _httpService.Get<Response<List<PenaltiesResponse>>>("v1/Penalties");
        }

        public async Task<Response<PenaltiesResponse>> GetByIdAsync(int Id)
        {
            return await _httpService.Get<Response<PenaltiesResponse>>($"v1/Penalties/{Id}");
        }

        public async Task<Response<int>> SaveAsync(AddEditPenalties model)
        {
            try
            {
                return await _httpService.Post<Response<int>>("v1/Penalties", model);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
