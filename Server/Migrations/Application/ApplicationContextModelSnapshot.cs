// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Server.Ctx;

#nullable disable

namespace Server.Migrations.Application
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Server.Ctx.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Server.Ctx.Entities.DepartmentBudget", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("ActualBudgetAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("BudgetAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCurrent")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("PercentegaScore")
                        .HasColumnType("int");

                    b.Property<decimal>("Q1")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Q2")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Q3")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Q4")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Year")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("DepartmentBudgets");
                });

            modelBuilder.Entity("Server.Ctx.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("BasicPay")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ConfirmationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("EmploymentStatus")
                        .HasColumnType("int");

                    b.Property<int>("EmploymentStatusId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("JoinedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaritalStatus")
                        .HasColumnType("int");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobilePhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NAPSA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PayGradeId")
                        .HasColumnType("int");

                    b.Property<string>("PrivateEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TerminationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("WorkEmail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("PayGradeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Server.Ctx.Entities.EmployeeIncentive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCurrent")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("PIPPayableMonthly")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalIncentivePayTarget")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalMonthlyPIP")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalPayableYearEnd")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeIncentives");
                });

            modelBuilder.Entity("Server.Ctx.Entities.EmployeeIncentiveMonthly", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("ActualPIPPayable")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<decimal>("ExpectedPIPPayable")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("FirstAuthorizer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("MDPenalty")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("Month")
                        .HasColumnType("date");

                    b.Property<int>("PercentageScore")
                        .HasColumnType("int");

                    b.Property<string>("SecondAuthorizer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThirdAuthorizer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeIncentiveMonthlies");
                });

            modelBuilder.Entity("Server.Ctx.Entities.PayGrade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("MaxSalary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MinSalary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("PayGrades");
                });

            modelBuilder.Entity("Server.Ctx.Entities.DepartmentBudget", b =>
                {
                    b.HasOne("Server.Ctx.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Server.Ctx.Entities.Employee", b =>
                {
                    b.HasOne("Server.Ctx.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.HasOne("Server.Ctx.Entities.PayGrade", "PayGrade")
                        .WithMany()
                        .HasForeignKey("PayGradeId");

                    b.Navigation("Department");

                    b.Navigation("PayGrade");
                });

            modelBuilder.Entity("Server.Ctx.Entities.EmployeeIncentive", b =>
                {
                    b.HasOne("Server.Ctx.Entities.Employee", "Employee")
                        .WithMany("EmployeeIncentives")
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Server.Ctx.Entities.EmployeeIncentiveMonthly", b =>
                {
                    b.HasOne("Server.Ctx.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.HasOne("Server.Ctx.Entities.Employee", "Employee")
                        .WithMany("EmployeeIncentiveMonthlies")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Server.Ctx.Entities.Employee", b =>
                {
                    b.Navigation("EmployeeIncentiveMonthlies");

                    b.Navigation("EmployeeIncentives");
                });
#pragma warning restore 612, 618
        }
    }
}
