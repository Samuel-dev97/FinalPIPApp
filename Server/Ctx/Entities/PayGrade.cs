using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Ctx.Entities
{
    public class PayGrade
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public string Name { get; set; }
        public decimal MaxSalary { get; set; }
        public decimal MinSalary { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}

