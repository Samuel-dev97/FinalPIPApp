using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Server.Models;

namespace Server.Data
{
    public partial class PIPContext : DbContext
    {
        public virtual DbSet<DepartmentBudgets> DepartmentBudgets { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<EmployeeIncentiveMonthlies> EmployeeIncentiveMonthlies { get; set; }
        public virtual DbSet<EmployeeIncentives> EmployeeIncentives { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<PayGrades> PayGrades { get; set; }
        public virtual DbSet<Penalties> Penalties { get; set; }

        public PIPContext(DbContextOptions<PIPContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeIncentiveMonthlies>(entity =>
            {
                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeIncentiveMonthlies)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<EmployeeIncentives>(entity =>
            {
                entity.HasOne(d => d.Budget)
                    .WithMany(p => p.EmployeeIncentives)
                    .HasForeignKey(d => d.BudgetId)
                    .HasConstraintName("BudgetId");
            });

            modelBuilder.Entity<Penalties>(entity =>
            {
                entity.HasOne(d => d.EmpIncentivesNavigation)
                    .WithMany(p => p.Penalties)
                    .HasForeignKey(d => d.EmpIncentives)
                    .HasConstraintName("FK__Penalties__EmpIn__3D2915A8");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Penalties)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Penalties__Emplo__3C34F16F");
            });

            OnModelCreatingGeneratedProcedures(modelBuilder);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
