using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.PayGrades
{
    public class AddEditPayGrade
    {
        public AddEditPayGrade()
        {

        }

        public AddEditPayGrade(PayGradeResponse model)
        {
            Id = model.Id;
            Name = model.Name;
            MaxSalary = model.MaxSalary;
            MinSalary = model.MinSalary;
            IsDeleted = model.IsDeleted;
            Monthly = model.Monthly;
            Description = model.Description;
        }

        public int Id { get; set; }
       
        public string Name { get; set; }
      
        public decimal? MaxSalary { get; set; }
      
        public decimal? MinSalary { get; set; }
        public bool IsDeleted { get; set; }
        public int? Monthly { get; set; }
        public string Description { get; set; }



    }
}
