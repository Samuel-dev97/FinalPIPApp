using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Models
{
    public partial class Penalties
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Charge { get; set; }
        public string PenaltyName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public int? EmployeeId { get; set; }
        public int? EmpIncentives { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Times { get; set; }

        [ForeignKey(nameof(EmpIncentives))]
        [InverseProperty(nameof(EmployeeIncentiveMonthlies.Penalties))]
        public virtual EmployeeIncentiveMonthlies EmpIncentivesNavigation { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(Employees.Penalties))]
        public virtual Employees Employee { get; set; }
    }
}
