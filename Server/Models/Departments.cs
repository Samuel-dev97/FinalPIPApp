using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Models
{
    public partial class Departments
    {
        public Departments()
        {
            DepartmentBudgets = new HashSet<DepartmentBudgets>();
            EmployeeIncentiveMonthlies = new HashSet<EmployeeIncentiveMonthlies>();
            Employees = new HashSet<Employees>();
        }

        [Key]
        public int Id { get; set; }
        public string DeptName { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Specification { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        [Column("logo")]
        public string Logo { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Score { get; set; }

        [InverseProperty("Department")]
        public virtual ICollection<DepartmentBudgets> DepartmentBudgets { get; set; }
        [InverseProperty("Department")]
        public virtual ICollection<EmployeeIncentiveMonthlies> EmployeeIncentiveMonthlies { get; set; }
        [InverseProperty("Department")]
        public virtual ICollection<Employees> Employees { get; set; }
    }
}
