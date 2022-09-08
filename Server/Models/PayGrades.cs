using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Models
{
    public partial class PayGrades
    {
        public PayGrades()
        {
            Employees = new HashSet<Employees>();
        }

        [Key]
        public int Id { get; set; }
        public string PayName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? MaxSalary { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? MinSalary { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? Monthly { get; set; }
        public string Description { get; set; }

        [InverseProperty("PayGrade")]
        public virtual ICollection<Employees> Employees { get; set; }
    }
}
