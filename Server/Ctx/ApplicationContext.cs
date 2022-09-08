using Microsoft.EntityFrameworkCore;
using Server.Ctx.Entities;
using Server.Extensions;
using Server.Interface;

namespace Server.Ctx
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        private readonly IAuthenticatedUserService _authenticatedUser;
        private readonly IDateTimeService _dateTimeService;

        public ApplicationContext(DbContextOptions<ApplicationContext> options, IAuthenticatedUserService authenticatedUser, IDateTimeService dateTimeService)
         : base(options)
        {
            _authenticatedUser = authenticatedUser;
            _dateTimeService = dateTimeService;
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentBudget> DepartmentBudgets { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeIncentive> EmployeeIncentives { get; set; }
        public DbSet<EmployeeIncentiveMonthly> EmployeeIncentiveMonthlies { get; set; }
        public DbSet<PayGrade> PayGrades { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var property in builder.Model.GetEntityTypes()
               .SelectMany(t => t.GetProperties())
               .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,2)");
            }
            base.OnModelCreating(builder);
        }
    }
}
