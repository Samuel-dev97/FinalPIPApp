using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Departments
{
    public class DepartmentsResponse
    {
        public int Id { get; set; }
        public string DeptName { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Specification { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string logo { get; set; }
        public decimal? Score { get; set; }
        public bool IsDeleted { get; set; }
    }
}
