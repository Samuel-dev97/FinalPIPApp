using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Employee
{
    public class EmployeeResponse
    {
        public int Id { get; set; }
        public int? EmploymentStatusId { get; set; }
        public string City { get; set; }
        public string Nationality { get; set; }
        public string NAPSA { get; set; }
        public int? MaritalStatus { get; set; }
        public string PayName { get; set; }
        public decimal? MaxSalary { get; set; }
        public DateTime? TerminationDate { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public DateTime? JoinedDate { get; set; }
        public string PrivateEmail { get; set; }
        public string WorkEmail { get; set; }
        public string MobilePhone { get; set; }
        public string FullName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime? DOB { get; set; }
        public int? Gender { get; set; }
        public decimal? BasicPay { get; set; }
        public int? DepartmentId { get; set; }
        public string DeptName { get; set; }
        public int? PayGradeId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
