using Server.Ctx.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Ctx.Entities
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       
        public int EmploymentStatusId { get; set; }
        public string City { get; set; }
        public string Nationality { get; set; }
        public string NAPSA { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public DateTime TerminationDate { get; set; }
        public DateTime ConfirmationDate { get; set; }
        public DateTime JoinedDate { get; set; }
        public string PrivateEmail { get; set; }
        public string WorkEmail { get; set; }
        public string MobilePhone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime DOB { get; set; }
        public GenderType Gender { get; set; }
        public decimal BasicPay { get; set; }
        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public int? PayGradeId { get; set; }
        public virtual PayGrade PayGrade { get; set; }
        public ICollection<EmployeeIncentive> EmployeeIncentives { get; set; }
        public ICollection<EmployeeIncentiveMonthly> EmployeeIncentiveMonthlies { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
