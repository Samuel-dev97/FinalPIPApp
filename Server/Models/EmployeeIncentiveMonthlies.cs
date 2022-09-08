using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Models
{
    [Index(nameof(DepartmentId), Name = "IX_EmployeeIncentiveMonthlies_DepartmentId")]
    [Index(nameof(EmployeeId), Name = "IX_EmployeeIncentiveMonthlies_EmployeeId")]
    public partial class EmployeeIncentiveMonthlies
    {
        public EmployeeIncentiveMonthlies()
        {
            Penalties = new HashSet<Penalties>();
        }

        [Key]
        public int Id { get; set; }
        [Column("ExpectedPIPPayable", TypeName = "decimal(18, 2)")]
        public decimal ExpectedPippayable { get; set; }
        [Column("ActualPIPPayable", TypeName = "decimal(18, 2)")]
        public decimal ActualPippayable { get; set; }
        [Column("MDPenalty", TypeName = "decimal(18, 2)")]
        public decimal Mdpenalty { get; set; }
        public int PercentageScore { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Month { get; set; }
        public int? EmployeeId { get; set; }
        public int? DepartmentId { get; set; }
        public string FirstAuthorizer { get; set; }
        public string SecondAuthorizer { get; set; }
        public string ThirdAuthorizer { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty(nameof(Departments.EmployeeIncentiveMonthlies))]
        public virtual Departments Department { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(Employees.EmployeeIncentiveMonthlies))]
        public virtual Employees Employee { get; set; }
        [InverseProperty("EmpIncentivesNavigation")]
        public virtual ICollection<Penalties> Penalties { get; set; }
    }
}
