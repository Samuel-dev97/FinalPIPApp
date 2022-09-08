using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Departments
{
    public class AddEditDepartmentBudgets
    {
        public AddEditDepartmentBudgets()
        {

        }
        public AddEditDepartmentBudgets(DepartmentBudgetsResponse model)
        {
            Id = model.Id;
            DepartmentId = model.DepartmentId;
            DeptName = model.DeptName;
            BudgetAmount = model.BudgetAmount;
            ActualBudgetAmount = model.ActualBudgetAmount;
            Q1 = model.Q1;
            Q2 = model.Q2;
            Q3 = model.Q3;
            Q4 = model.Q4;
            PercentegaScore = model.PercentegaScore;
            Year = model.Year;
            CreatedOn = model.CreatedOn;
            UpdatedOn = model.UpdatedOn;
            IsDeleted = model.IsDeleted;
            IsCurrent = model.IsCurrent;
            GM = model.GM;
            Month = model.Month;
            Date = model.Date;
        }
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string DeptName { get; set; }
        public decimal? BudgetAmount { get; set; }
        public decimal? ActualBudgetAmount { get; set; }
        public decimal? Q1 { get; set; }
        public decimal? Q2 { get; set; }
        public decimal? Q3 { get; set; }
        public decimal? Q4 { get; set; }
        public decimal? PercentegaScore { get; set; }
        public string Year { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsCurrent { get; set; }
        public decimal? GM { get; set; }
        public int? Month { get; set; }
        public string Date { get; set; }
    }
}
