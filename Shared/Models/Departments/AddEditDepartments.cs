using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Departments
{
    public class AddEditDepartments
    {

        public AddEditDepartments()
        {

        }
        public AddEditDepartments(DepartmentsResponse model)
        {
            Id = model.Id;
            DeptName = model.DeptName;
            Code = model.Code;
            Description = model.Description;
            Specification = model.Specification;


            CreatedOn = model.CreatedOn;
            UpdatedOn = model.UpdatedOn;
            logo = model.logo;
            Score = model.Score;
            IsDeleted = model.IsDeleted;

        }
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
