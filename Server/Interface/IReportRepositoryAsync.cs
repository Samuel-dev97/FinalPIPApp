
using Server.Enums;
using Server.Features.ReportFeatures.Queries;
using Server.Models;

namespace Server.Interface
{
    public interface IReportRepositoryAsync
    {
        Task<List<EmployeeViewModel>> GetAllEmployeesAsync(string? Gender, Status? Status);
        Task<List<Employees>> GetSingleEmployeeReportAsync(int Id);

        Task<List<EmployeeViewModel>> GetAllEmployeesExcelAsync(Enums.Status? Status, string Gender);
        Task<List<EmployeeViewModel>> GetAllEmployeeWorkExcelAsync();

        ////Form
        //Task<List<FormViewModel>> GetAllEmployeesFormAsync(string? Gender, Status? Status);
        //Task<List<EmployeeIncentives>> GetSingleFormReportAsync(int Id);

        //Task<List<FormViewModel>> GetAllFormExcelAsync(Enums.Status? Status, string Gender);
        //Task<List<FormViewModel>> GetAllFormWorkExcelAsync();


    }
}
