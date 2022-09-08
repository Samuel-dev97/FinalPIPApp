using Client.Interfaces;
using Client.Models;
using System.Threading.Tasks;

namespace Client.Services
{
    public class ReportRepositoryAsync : IReportRepositoryAsync
    {
        private readonly IHttpService _httpService;
        public ReportRepositoryAsync(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<ReportResponse> GetAllAsync()
        {
            return await _httpService.Get<ReportResponse>($"v1/Reports");
        }
        public async Task<ReportResponse> GetAllSSSAsync()
        {
            return await _httpService.Get<ReportResponse>($"v1/Reports/sss");
        }
        public async Task<ReportResponse> GetAllZAMAsync()
        {
            return await _httpService.Get<ReportResponse>($"v1/Reports/zam");
        }
        public async Task<ReportResponse> GetAllPIAsync()
        {
            return await _httpService.Get<ReportResponse>($"v1/Reports/pi");
        }
        public async Task<ReportResponse> GetAllCSAsync()
        {
            return await _httpService.Get<ReportResponse>($"v1/Reports/cs");
        }
        public async Task<ReportResponse> GetAllCFDAsync()
        {
            return await _httpService.Get<ReportResponse>($"v1/Reports/cfd");
        }
        public async Task<ReportResponse> GetAllASLAsync()
        {
            return await _httpService.Get<ReportResponse>($"v1/Reports/asl");
        }

        public async Task<ReportResponse> GetManPowerReport()
        {
            return await _httpService.Get<ReportResponse>($"v1/Report/man-power");
        }

        public async Task<ReportResponse> GetContractReportAsync()
        {
            return await _httpService.Get<ReportResponse>($"v1/Report/contract-length");
        }

        public async Task<ReportResponse> GetContractDetailsReportAsync()
        {
            return await _httpService.Get<ReportResponse>($"v1/Report/contract-details");
        }

        public async Task<ReportResponse> GetSingelGuardReportAsync(int id)
        {
            return await _httpService.Get<ReportResponse>($"v1/Report/{id}");
        }

        public async Task<ReportResponse> GetGuardLeaveDaysReportAsync(int id)
        {
            return await _httpService.Get<ReportResponse>($"v1/Report/leave-days");
        }

        public async Task<ReportResponse> GetDependentReportAsync()
        {
            return await _httpService.Get<ReportResponse>($"v1/Report/dependents");
        }

        public async Task<ReportResponse> GetRosterReportAsync()
        {
            return await _httpService.Get<ReportResponse>($"v1/Report/roster");
        }

        public async Task<ReportResponse> GetSingleEnumerationReportAsync(int id)
        {
            return await _httpService.Get<ReportResponse>($"v1/Report/enumeration/{id}");
        }
    }
}
