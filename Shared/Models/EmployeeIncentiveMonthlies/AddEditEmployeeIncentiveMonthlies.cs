using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.EmployeeIncentiveMonthlies
{
    public class AddEditEmployeeIncentiveMonthlies
    {
        public AddEditEmployeeIncentiveMonthlies()
        {

        }

        public AddEditEmployeeIncentiveMonthlies(EmployeeIncentiveMonthliesResponse model)
        {
            Id = model.Id;
            ExpectedPIPPayable = model.ExpectedPIPPayable;
            ActualPIPPayable = model.ActualPIPPayable;
            MDPenalty = model.MDPenalty;
            PercentageScore = model.PercentageScore;
            Month = model.Month;
            DeptName = model.DeptName;
            FirstName = model.DeptName;
            LastName = model.DeptName;
            EmployeeId = model.EmployeeId;
            FirstAuthorizer = model.FirstAuthorizer;
            SecondAuthorizer = model.SecondAuthorizer;
            ThirdAuthorizer = model.ThirdAuthorizer;
            IsDeleted = model.IsDeleted;
            CreatedOn = model.CreatedOn;
            UpdatedOn = model.UpdatedOn;
          
           
        }

        public int Id { get; set; }
        public decimal ExpectedPIPPayable { get; set; }
        public decimal ActualPIPPayable { get; set; }
        public decimal MDPenalty { get; set; }
        public int PercentageScore { get; set; }
        public DateTime? Month { get; set; }
        public int? EmployeeId { get; set; }
        public int? DepartmentId { get; set; }
        public string DeptName { get; set; }
        public string FirstAuthorizer { get; set; }
        public string SecondAuthorizer { get; set; }
        public string ThirdAuthorizer { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
