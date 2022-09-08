using Microsoft.EntityFrameworkCore;
using Server.Ctx.Entities;

namespace Server.Ctx
{
    public interface IApplicationContext
    {
        DbSet<DepartmentBudget> DepartmentBudgets { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<EmployeeIncentiveMonthly> EmployeeIncentiveMonthlies { get; set; }
        DbSet<EmployeeIncentive> EmployeeIncentives { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<PayGrade> PayGrades { get; set; }
    }
}