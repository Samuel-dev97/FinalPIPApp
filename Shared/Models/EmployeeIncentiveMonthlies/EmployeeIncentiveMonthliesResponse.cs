using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.EmployeeIncentiveMonthlies
{
    public class EmployeeIncentiveMonthliesResponse
    {
        public int Id { get; set; }
        public decimal ExpectedPIPPayable { get; set; }
        public decimal ActualPIPPayable { get; set; }
        public decimal MDPenalty { get; set; }
        public int PercentageScore { get; set; }
        public DateTime? Month { get; set; }
        public int? EmployeeId { get; set; }
        public int? DepartmentId { get; set; }
        public string FirstAuthorizer { get; set; }
        public string SecondAuthorizer { get; set; }
        public string ThirdAuthorizer { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DeptName { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}

