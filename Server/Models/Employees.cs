using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Server.Models
{
    [Index(nameof(DepartmentId), Name = "IX_Employees_DepartmentId")]
    [Index(nameof(PayGradeId), Name = "IX_Employees_PayGradeId")]
    public partial class Employees
    {
        public Employees()
        {
            EmployeeIncentiveMonthlies = new HashSet<EmployeeIncentiveMonthlies>();
            EmployeeIncentives = new HashSet<EmployeeIncentives>();
            Penalties = new HashSet<Penalties>();
        }

        [Key]
        public int Id { get; set; }
        public int? EmploymentStatusId { get; set; }
        public string City { get; set; }
        public string Nationality { get; set; }
        [Column("NAPSA")]
        public string Napsa { get; set; }
        public int? MaritalStatus { get; set; }
        public DateTime? TerminationDate { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public DateTime? JoinedDate { get; set; }
        public string PrivateEmail { get; set; }
        public string WorkEmail { get; set; }
        public string MobilePhone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [Column("DOB")]
        public DateTime? Dob { get; set; }
        public int? Gender { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? BasicPay { get; set; }
        public int? DepartmentId { get; set; }
        public int? PayGradeId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty(nameof(Departments.Employees))]
        public virtual Departments Department { get; set; }
        [ForeignKey(nameof(PayGradeId))]
        [InverseProperty(nameof(PayGrades.Employees))]
        public virtual PayGrades PayGrade { get; set; }
        [InverseProperty("Employee")]
        public virtual ICollection<EmployeeIncentiveMonthlies> EmployeeIncentiveMonthlies { get; set; }
        [InverseProperty("Employee")]
        public virtual ICollection<EmployeeIncentives> EmployeeIncentives { get; set; }
        [InverseProperty("Employee")]
        public virtual ICollection<Penalties> Penalties { get; set; }
    }
}
