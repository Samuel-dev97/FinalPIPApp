using Microsoft.EntityFrameworkCore;
using Server.Ctx;
using Server.Enums;
using Server.Features.ReportFeatures.Queries;
using Server.Interface;
using Server.Models;

namespace Server.Repository
{

    public class ReportRepositoryAsync : GenericRepositoryAsync<EmployeeIncentives>, IReportRepositoryAsync
    {
        private readonly DbSet<EmployeeIncentives> _report;
      


        public ReportRepositoryAsync(ApplicationContext dbContext) : base(dbContext)
        {
            _report = dbContext.Set<EmployeeIncentives>();

        }

        public async Task<List<EmployeeViewModel>> GetAllEmployeesAsync(string? Gender, Status? Status)
        {
            return await _report.Select(model => new EmployeeViewModel
            {
                Id = model.Id,
                TotalIncentivePayTarget = model.TotalIncentivePayTarget,
                TotalPayableYearEnd = model.TotalPayableYearEnd,
                TotalMonthlyPIP = model.TotalMonthlyPip,
                PIPPayableMonthly = model.PippayableMonthly,
                FirstName = model.Employee.FirstName,
                LastName = model.Employee.LastName,
                //IsCurrent = model.IsCurrent;
                IsDeleted = model.IsDeleted,
                EmployeeId = model.EmployeeId,
                BudgetId = model.BudgetId,
                FinalScore = model.FinalScore,
                Pay = model.Pay,
                PenaltyCharge = model.PenaltyCharge,
                Month = model.Month,
                Date = model.Date,
                //FullName = model.FullName,
                CreatedOn = model.CreatedOn,
                UpdatedOn = model.UpdatedOn,
            }).ToListAsync();
        }

        public async Task<List<EmployeeViewModel>> GetAllGuardExcelAsync(Enums.Status? status, string? Gender)
        {
            return await _report.Select(model => new EmployeeViewModel
            {
                Id = model.Id,
                TotalIncentivePayTarget = model.TotalIncentivePayTarget,
                TotalPayableYearEnd = model.TotalPayableYearEnd,
                TotalMonthlyPIP = model.TotalMonthlyPip,
                PIPPayableMonthly = model.PippayableMonthly,
                FirstName = model.Employee.FirstName,
                LastName = model.Employee.LastName,
                //IsCurrent = model.IsCurrent;
                IsDeleted = model.IsDeleted,
                EmployeeId = model.EmployeeId,
                BudgetId = model.BudgetId,
                FinalScore = model.FinalScore,
                Pay = model.Pay,
                PenaltyCharge = model.PenaltyCharge,
                Month = model.Month,
                Date = model.Date,
                //FullName = model.FullName,
                CreatedOn = model.CreatedOn,
                UpdatedOn = model.UpdatedOn,
            }).ToListAsync();
        }

        public async Task<List<EmployeeViewModel>> GetAllGuardWorkExcelAsync()
        {
            return await _report.Select(model => new EmployeeViewModel
            {
                Id = model.Id,
                TotalIncentivePayTarget = model.TotalIncentivePayTarget,
                TotalPayableYearEnd = model.TotalPayableYearEnd,
                TotalMonthlyPIP = model.TotalMonthlyPip,
                PIPPayableMonthly = model.PippayableMonthly,
                FirstName = model.Employee.FirstName,
                LastName = model.Employee.LastName,
                //IsCurrent = model.IsCurrent;
                IsDeleted = model.IsDeleted,
                EmployeeId = model.EmployeeId,
                BudgetId = model.BudgetId,
                FinalScore = model.FinalScore,
                Pay = model.Pay,
                PenaltyCharge = model.PenaltyCharge,
                Month = model.Month,
                Date = model.Date,
                //FullName = model.FullName,
                CreatedOn = model.CreatedOn,
                UpdatedOn = model.UpdatedOn,

                
            }).ToListAsync();
        }

        //public async Task<List<ContractViewModel>> GetContractLengthReportAsync()
        //{
        //    return await _contractReport.Select(x => new ContractViewModel
        //    {
        //        EmployeeId = x.Guard.EmployeeId == 0 ? 0 : x.Guard.EmployeeId,
        //        FullName = x.Guard.Forenames + " " + x.Guard.Surname,
        //        ManNumber = x.Guard.ManNumber == null ? "ManNumber" : x.Guard.ManNumber,
        //        NRC = x.Guard.NRC == null ? "null" : x.Guard.NRC,
        //        StartDate = x.StartDate == null ? DateTime.Now : x.StartDate,
        //        EndDate = x.EndDate == null ? DateTime.Now : x.EndDate,
        //        IsCurrent = x.IsCurrent == null ? false : x.IsCurrent,
        //        Status = x.Guard.Status == null ? Status.Active : x.Guard.Status,
        //        Gender = x.Guard.Gender == null ? "gender" : x.Guard.Gender,
        //    }).Where(x => x.IsCurrent == true).ToListAsync();
        //}






       // public async Task<List<Employees>> GetSingleGuardReportAsync(int Id)
        //{
        //    //  Guard _guard = new Guard();
        //    try
        //    {
        //        return await _report.Where(model => model.Id == Id)
        //             .Select(model => new EmployeeIncentives()
        //             {
        //                 Id = model.Id,
        //                 TotalIncentivePayTarget = model.TotalIncentivePayTarget,
        //                 TotalPayableYearEnd = model.TotalPayableYearEnd,
        //                 TotalMonthlyPip = model.TotalMonthlyPip,
        //                 PippayableMonthly = model.PippayableMonthly,
        //                 //Employee.FirstName = model.Employee.FirstName,
        //                 Month = model.Month,
        //                 //IsCurrent = model.IsCurrent;
        //                 IsDeleted = model.IsDeleted,
        //                 EmployeeId = model.EmployeeId,
        //                 BudgetId = model.BudgetId,
        //                 FinalScore = model.FinalScore,
        //                 Pay = model.Pay,
        //                 PenaltyCharge = model.PenaltyCharge,
        //                 IsCurrent = model.Employee.Nat,
        //                 Date = model.Date,
        //                 //FullName = model.FullName,
        //                 CreatedOn = model.CreatedOn,
        //                 UpdatedOn = model.UpdatedOn,

        //             }).ToListAsync();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    ///  return _guard;
       // }

      

        //public static string GetFormatEmployeeId(string Id)
        //{
        //    var EmployeeId = "";
        //    if (Id.Length == 1)
        //    {
        //        EmployeeId = "00000" + Id;
        //    }
        //    else if (Id.Length == 2)
        //    {
        //        EmployeeId = "0000" + Id;
        //    }
        //    else if (Id.Length == 3)
        //    {
        //        EmployeeId = "000" + Id;
        //    }
        //    else if (Id.Length == 4)
        //    {
        //        EmployeeId = "00" + Id;
        //    }
        //    else if (Id.Length == 4)
        //    {
        //        EmployeeId = "0" + Id;
        //    }
        //    else
        //    {
        //        EmployeeId = Id;
        //    }

        //    return EmployeeId;
        //}
       
        //public static int GetGuardAge(DateTime? dateOfBirth)
        //{
        //    var today = DateTime.Today;

        //    var a = (today.Year * 100 + today.Month) * 100 + today.Day;
        //    var b = (dateOfBirth?.Year * 100 + dateOfBirth?.Month) * 100 + dateOfBirth?.Day;

        //    return (int)((a - b) / 10000);
        //}

        //public static int CalculateAge(DateTime? birthDate)
        //{
        //    //int age = DateTime.Now.Year - birthDate.Value.Year;

        //    //// For leap years we need this
        //    //if (birthDate > DateTime.Now.AddYears(-age))
        //    //    age--;
        //    //// Don't use:
        //    //// if (birthDate.AddYears(age) > now) 
        //    ////     age--;

        //    //return age;
        //}

        //public Task<List<Employees>> GetSingleEmployeeReportAsync(int Id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<List<EmployeeViewModel>> GetAllEmployeesExcelAsync(Status? Status, string Gender)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<List<EmployeeViewModel>> GetAllEmployeeWorkExcelAsync()
        {
            return await _report.Select(model => new EmployeeViewModel
            {
                Id = model.Id,
                TotalIncentivePayTarget = model.TotalIncentivePayTarget,
                TotalPayableYearEnd = model.TotalPayableYearEnd,
                TotalMonthlyPIP = model.TotalMonthlyPip,
                PIPPayableMonthly = model.PippayableMonthly,
                FirstName = model.Employee.FirstName,
                LastName = model.Employee.LastName,
                //IsCurrent = model.IsCurrent;
                IsDeleted = model.IsDeleted,
                EmployeeId = model.EmployeeId,
                BudgetId = model.BudgetId,
                FinalScore = model.FinalScore,
                Pay = model.Pay,
                PenaltyCharge = model.PenaltyCharge,
                Month = model.Month,
                Date = model.Date,
                //FullName = model.FullName,
                CreatedOn = model.CreatedOn,
                UpdatedOn = model.UpdatedOn,
            }).ToListAsync();
        }

        public Task<List<Employees>> GetSingleEmployeeReportAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<EmployeeViewModel>> GetAllEmployeesExcelAsync(Status? Status, string Gender)
        {
            throw new NotImplementedException();
        }
    }
}
