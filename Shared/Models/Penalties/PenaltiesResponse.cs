using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Penalties
{
    public class PenaltiesResponse
    {
        public int Id { get; set; }
        public decimal? Charge { get; set; }
        public string PenaltyName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public int? EmployeeId { get; set; }
        public int? EmpIncentives { get; set; }
        public decimal? Times { get; set; }
    }
}
