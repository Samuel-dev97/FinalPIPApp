using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.PayGrades
{
    public class PayGradeResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? MaxSalary { get; set; }
        public decimal? MinSalary { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? Monthly { get; set; }
        public string Description { get; set; }
    }
}
