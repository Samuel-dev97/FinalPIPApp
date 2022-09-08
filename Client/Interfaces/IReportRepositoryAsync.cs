using Client.Models;
using System.Threading.Tasks;

namespace Client.Interfaces
{
    interface IReportRepositoryAsync
    {
        Task<ReportResponse> GetAllAsync();
        Task<ReportResponse> GetAllCSAsync();
        Task<ReportResponse> GetAllSSSAsync();
        Task<ReportResponse> GetAllZAMAsync();
        Task<ReportResponse> GetAllPIAsync();
        Task<ReportResponse> GetAllCFDAsync();
        Task<ReportResponse> GetAllASLAsync();
        Task<ReportResponse> GetManPowerReport();
        Task<ReportResponse> GetContractReportAsync();
        Task<ReportResponse> GetContractDetailsReportAsync();
        Task<ReportResponse> GetSingelGuardReportAsync(int id);
        Task<ReportResponse> GetSingleEnumerationReportAsync(int id);

    }
}
