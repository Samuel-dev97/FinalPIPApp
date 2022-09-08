using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Models
{
    [Index(nameof(EmployeeId), Name = "IX_EmployeeIncentives_EmployeeId")]
    public partial class EmployeeIncentives
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? TotalIncentivePayTarget { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? TotalPayableYearEnd { get; set; }
        [Column("TotalMonthlyPIP", TypeName = "decimal(18, 2)")]
        public decimal? TotalMonthlyPip { get; set; }
        [Column("PIPPayableMonthly", TypeName = "decimal(18, 2)")]
        public decimal? PippayableMonthly { get; set; }
        public bool? IsCurrent { get; set; }
        public bool? IsDeleted { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? BudgetId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? FinalScore { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Pay { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? PenaltyCharge { get; set; }
        public string Month { get; set; }
        public string Date { get; set; }
        public string FirstAuth { get; set; }
        public string SecondAuth { get; set; }
        public string ThirdAuth { get; set; }
        public string Comment1 { get; set; }
        public string Comment2 { get; set; }
        public string Comment3 { get; set; }
        public string ForeName { get; set; }
        public string PenaltyName { get; set; }

        [ForeignKey(nameof(BudgetId))]
        [InverseProperty(nameof(DepartmentBudgets.EmployeeIncentives))]
        public virtual DepartmentBudgets Budget { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(Employees.EmployeeIncentives))]
        public virtual Employees Employee { get; set; }
    }
}
