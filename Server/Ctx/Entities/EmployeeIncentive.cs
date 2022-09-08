using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Ctx.Entities
{
    public class EmployeeIncentive
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal TotalIncentivePayTarget { get; set; }
        public decimal TotalPayableYearEnd { get; set; } 
        public decimal TotalMonthlyPIP { get; set; }
        public decimal PIPPayableMonthly { get; set; }
        public bool IsCurrent { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
