using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Models
{
    [Index(nameof(DepartmentId), Name = "IX_DepartmentBudgets_DepartmentId")]
    public partial class DepartmentBudgets
    {
        public DepartmentBudgets()
        {
            EmployeeIncentives = new HashSet<EmployeeIncentives>();
        }

        [Key]
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? BudgetAmount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ActualBudgetAmount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Q1 { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Q2 { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Q3 { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Q4 { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? PercentegaScore { get; set; }
        public string Year { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsCurrent { get; set; }
        [Column("GM", TypeName = "decimal(18, 0)")]
        public decimal? Gm { get; set; }
        public int? Month { get; set; }
        [StringLength(50)]
        public string Date { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty(nameof(Departments.DepartmentBudgets))]
        public virtual Departments Department { get; set; }
        [InverseProperty("Budget")]
        public virtual ICollection<EmployeeIncentives> EmployeeIncentives { get; set; }
    }
}
