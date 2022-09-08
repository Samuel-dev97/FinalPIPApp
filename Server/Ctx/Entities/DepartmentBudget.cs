using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Ctx.Entities
{
    public class DepartmentBudget
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public virtual Department Department { get; set; } 
        public int DepartmentId { get; set; }
        public decimal BudgetAmount { get; set; }
        public decimal ActualBudgetAmount { get; set;}
        public decimal Q1 { get; set; }
        public decimal Q2 { get; set; }
        public decimal Q3 { get; set; }
        public decimal Q4 { get; set; }
        public int PercentegaScore { get; set; }
        public string Year { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsCurrent { get;set; } = false;
    }
}
