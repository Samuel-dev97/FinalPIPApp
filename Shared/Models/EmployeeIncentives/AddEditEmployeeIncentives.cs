using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.EmployeeIncetives
{

    public class AddEditEmployeeIncentives
    {
        public AddEditEmployeeIncentives()
        {

        }

        public AddEditEmployeeIncentives(EmployeeIncentivesResponse model)
        {
            Id = model.Id;
            TotalIncentivePayTarget = model.TotalIncentivePayTarget;
            TotalPayableYearEnd = model.TotalPayableYearEnd;
            TotalMonthlyPIP = model.TotalMonthlyPIP;
            PIPPayableMonthly = model.PIPPayableMonthly;
            FirstName = model.FirstName;
            LastName = model.LastName;
            //IsCurrent = model.IsCurrent;
            IsDeleted = model.IsDeleted;
            EmployeeId = model.EmployeeId;
            BudgetId = model.BudgetId;
            FinalScore = model.FinalScore;
            Pay = model.Pay;
            PenaltyCharge = model.PenaltyCharge;
            Month = model.Month;
            Date = model.Date;
            FullName = model.FullName;
            FirstAuth = model.FirstAuth;
            SecondAuth = model.SecondAuth;
            ThirdAuth = model.ThirdAuth;
            Comment1 = model.Comment1;
            Comment2 = model.Comment2;
            Comment3 = model.Comment3;
            ForeName = model.ForeName;
            PenaltyName = model.PenaltyName;
            CreatedOn = model.CreatedOn;
            UpdatedOn = model.UpdatedOn;

        }
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
        public string FirstAuth { get; set; }
        public string SecondAuth { get; set; }
        public string ThirdAuth { get; set; }
        public string Comment1 { get; set; }
        public string Comment2 { get; set; }
        public string Comment3 { get; set; }
        public string ForeName { get; set; }
        public string PenaltyName { get; set; }
    }
}

