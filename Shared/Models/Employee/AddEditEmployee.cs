using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Employee
{

    public class AddEditEmployee
    {
        public AddEditEmployee()
        {

        }
        public AddEditEmployee(EmployeeResponse model)
        {
            Id = model.Id;
           
            EmploymentStatusId = model.EmploymentStatusId;
            City = model.City;
            Nationality = model.Nationality;
            NAPSA = model.NAPSA;
            MaritalStatus = model.MaritalStatus;
            PayName = model.PayName;
            MaxSalary = model.MaxSalary;
            TerminationDate = model.TerminationDate;
            ConfirmationDate = model.ConfirmationDate;
            JoinedDate = model.JoinedDate;
            PrivateEmail = model.PrivateEmail;
            WorkEmail = model.WorkEmail;
            MobilePhone = model.MobilePhone;
            FirstName = model.FirstName;
            LastName = model.LastName;
            FirstName = model.FirstName;
            MiddleName = model.MiddleName;
            DOB = model.DOB;
            Gender = model.Gender;
            BasicPay = model.BasicPay;
            
            DepartmentId = model.DepartmentId;
            DeptName = model.DeptName;
            PayGradeId = model.PayGradeId;
            IsDeleted = model.IsDeleted;
            CreatedOn = model.CreatedOn;
            UpdatedOn = model.UpdatedOn;
        }

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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
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
