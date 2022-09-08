using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Ctx.Entities
{
    public class EmployeeIncentiveMonthly
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal ExpectedPIPPayable { get; set; }
        public decimal ActualPIPPayable { get; set; }
        public decimal MDPenalty { get; set; }
        public int PercentageScore { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Month { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public string FirstAuthorizer { get; set; }
        public string SecondAuthorizer { get; set; }
        public string ThirdAuthorizer { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
