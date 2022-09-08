using Server.Enums;

namespace Server.Features.ReportFeatures.Queries
{
    public class ReportViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NRC { get; set; }
        public decimal BasicPay { get; set; }
        public string MaritalStatus { get; set; }
        public string? Company { get; set; }
        public string? City { get; set; }
        public string PayName { get; set; }
    }

    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public decimal? TotalIncentivePayTarget { get; set; }
        public decimal? TotalPayableYearEnd { get; set; }
        public decimal? TotalMonthlyPIP { get; set; }
        public decimal? PIPPayableMonthly { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? EmployeeId { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? BudgetId { get; set; }
        public decimal? FinalScore { get; set; }
        public decimal? Pay { get; set; }
        public decimal? PenaltyCharge { get; set; }
        public string Month { get; set; }
        public string Date { get; set; }
        public string FullName { get; set; }
    }
    public class FormViewModel
    {
        public int Id { get; set; }
        public decimal? TotalIncentivePayTarget { get; set; }
        public decimal? TotalPayableYearEnd { get; set; }
        public decimal? TotalMonthlyPIP { get; set; }
        public decimal? PIPPayableMonthly { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? EmployeeId { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? BudgetId { get; set; }
        public decimal? FinalScore { get; set; }
        public decimal? Pay { get; set; }
        public decimal? PenaltyCharge { get; set; }
        public string Month { get; set; }
        public string Date { get; set; }
        public string FullName { get; set; }
    }
}
