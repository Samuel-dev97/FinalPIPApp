﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Server.Data
{
    public partial interface IPIPContextProcedures
    {
        Task<List<DepartmentBudgetsALLResult>> DepartmentBudgetsALLAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> DepartmentBudgetsCREATEAsync(int? DepartmentId, decimal? BudgetAmount, decimal? ActualBudgetAmount, decimal? Q1, decimal? Q2, decimal? Q3, decimal? Q4, decimal? PercentegaScore, string Year, DateTime? CreatedOn, DateTime? UpdatedOn, bool? IsDeleted, bool? IsCurrent, decimal? GM, int? Month, string Date, OutputParameter<int?> Identity, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> DepartmentBudgetsDELETEAsync(int? Id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<DepartmentBudgetsSINGLEResult>> DepartmentBudgetsSINGLEAsync(int? Id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> DepartmentBudgetsUPDATEAsync(int? Id, int? DepartmentId, decimal? BudgetAmount, decimal? ActualBudgetAmount, decimal? Q1, decimal? Q2, decimal? Q3, decimal? Q4, decimal? PercentegaScore, string Year, DateTime? CreatedOn, DateTime? UpdatedOn, bool? IsDeleted, bool? IsCurrent, decimal? GM, int? Month, string Date, OutputParameter<int?> Identity, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<DepartmentsALLResult>> DepartmentsALLAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> DepartmentsCREATEAsync(string Name, string Code, string Description, string Specification, bool? IsDeleted, DateTime? CreatedOn, DateTime? UpdatedOn, string logo, decimal? Score, OutputParameter<int?> Identity, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> DepartmentsDELETEAsync(int? Id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<DepartmentsSINGLEResult>> DepartmentsSINGLEAsync(int? Id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> DepartmentsUPDATEAsync(int? Id, string DeptName, string Code, string Description, string Specification, bool? IsDeleted, DateTime? CreatedOn, DateTime? UpdatedOn, string logo, decimal? Score, OutputParameter<int?> Identity, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<EmployeeIncentiveMonthliesALLResult>> EmployeeIncentiveMonthliesALLAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> EmployeeIncentiveMonthliesCREATEAsync(decimal? ExpectedPIPPayable, decimal? ActualPIPPayable, decimal? MDPenalty, int? PercentageScore, DateTime? Month, int? EmployeeId, int? DepartmentId, string FirstAuthorizer, string SecondAuthorizer, string ThirdAuthorizer, bool? IsDeleted, OutputParameter<int?> Identity, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> EmployeeIncentiveMonthliesDELETEAsync(int? Id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<EmployeeIncentiveMonthliesSINGLEResult>> EmployeeIncentiveMonthliesSINGLEAsync(int? Id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> EmployeeIncentiveMonthliesUPDATEAsync(int? Id, decimal? ExpectedPIPPayable, decimal? ActualPIPPayable, decimal? MDPenalty, int? PercentageScore, DateTime? Month, int? EmployeeId, int? DepartmentId, string FirstAuthorizer, string SecondAuthorizer, string ThirdAuthorizer, bool? IsDeleted, OutputParameter<int?> Identity, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<EmployeeIncentivesALLResult>> EmployeeIncentivesALLAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> EmployeeIncentivesCREATEAsync(decimal? TotalIncentivePayTarget, decimal? TotalPayableYearEnd, decimal? TotalMonthlyPIP, decimal? PIPPayableMonthly, bool? IsCurrent, int? EmployeeId, bool? IsDeleted, DateTime? CreatedOn, DateTime? UpdatedOn, int? BudgetId, decimal? FinalScore, decimal? Pay, decimal? PenaltyCharge, string Month, string Date, string FirstAuth, string SecondAuth, string ThirdAuth, string Comment1, string Comment2, string Comment3, string ForeName, string PenaltyName, OutputParameter<int?> Identity, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> EmployeeIncentivesDELETEAsync(int? Id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<EmployeeIncentivesSINGLEResult>> EmployeeIncentivesSINGLEAsync(int? Id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> EmployeeIncentivesUPDATEAsync(int? Id, decimal? TotalIncentivePayTarget, decimal? TotalPayableYearEnd, decimal? TotalMonthlyPIP, decimal? PIPPayableMonthly, bool? IsCurrent, int? EmployeeId, DateTime? UpdatedOn, bool? IsDeleted, DateTime? CreatedOn, int? BudgetId, decimal? FinalScore, decimal? Pay, decimal? PenaltyCharge, string Month, string Date, string FirstAuth, string SecondAuth, string ThirdAuth, string Comment1, string Comment2, string Comment3, string ForeName, string PenaltyName, OutputParameter<int?> Identity, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<EmployeesALLResult>> EmployeesALLAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> EmployeesCREATEAsync(int? EmploymentStatusId, string City, string Nationality, string NAPSA, int? MaritalStatus, DateTime? TerminationDate, DateTime? ConfirmationDate, DateTime? JoinedDate, string PrivateEmail, string WorkEmail, string MobilePhone, string FirstName, string LastName, string MiddleName, DateTime? DOB, int? Gender, decimal? BasicPay, int? DepartmentId, int? PayGradeId, DateTime? UpdatedOn, bool? IsDeleted, DateTime? CreatedOn, OutputParameter<int?> Identity, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> EmployeesDELETEAsync(int? Id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<EmployeesSINGLEResult>> EmployeesSINGLEAsync(int? Id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> EmployeesUPDATEAsync(int? Id, int? EmploymentStatusId, string City, string Nationality, string NAPSA, int? MaritalStatus, DateTime? TerminationDate, DateTime? ConfirmationDate, DateTime? JoinedDate, string PrivateEmail, string WorkEmail, string MobilePhone, string FirstName, string LastName, string MiddleName, DateTime? DOB, int? Gender, decimal? BasicPay, int? DepartmentId, int? PayGradeId, DateTime? UpdatedOn, bool? IsDeleted, DateTime? CreatedOn, OutputParameter<int?> Identity, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> EmployeIncentivesCREATEAsync(decimal? TotalIncentivePayTarget, decimal? TotalPayableYearEnd, decimal? TotalMonthlyPIP, decimal? PIPPayableMonthly, bool? IsCurrent, int? EmployeeId, DateTime? UpdatedOn, bool? IsDeleted, DateTime? CreatedOn, OutputParameter<int?> Identity, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> EmployeIncentivesUPDATEAsync(int? Id, decimal? TotalIncentivePayTarget, decimal? TotalPayableYearEnd, decimal? TotalMonthlyPIP, decimal? PIPPayableMonthly, bool? IsCurrent, int? EmployeeId, DateTime? UpdatedOn, bool? IsDeleted, DateTime? CreatedOn, OutputParameter<int?> Identity, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<GetAllEmployeesReportResult>> GetAllEmployeesReportAsync(string Gender, int? Status, string StatementType, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<PayGradesALLResult>> PayGradesALLAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> PayGradesCREATEAsync(string PayName, decimal? MaxSalary, decimal? MinSalary, DateTime? UpdatedOn, bool? IsDeleted, DateTime? CreatedOn, int? Monthly, string Description, OutputParameter<int?> Identity, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> PayGradesDELETEAsync(int? Id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<PayGradesSINGLEResult>> PayGradesSINGLEAsync(int? Id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> PayGradesUPDATEAsync(int? Id, string PayName, decimal? MaxSalary, decimal? MinSalary, int? Monthly, string Description, bool? IsDeleted, OutputParameter<int?> Identity, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<PenaltiesALLResult>> PenaltiesALLAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<PenaltiesSINGLEResult>> PenaltiesSINGLEAsync(int? Id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> PenaltiesUPDATEAsync(int? Id, decimal? Charge, string PenaltyName, DateTime? CreatedOn, DateTime? LastModifiedOn, string CreatedBy, string LastModifiedBy, int? EmployeeId, int? EmpIncentives, decimal? Times, OutputParameter<int?> Identity, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> PenaltyCREATEAsync(decimal? Charge, string PenaltyName, DateTime? CreatedOn, DateTime? LastModifiedOn, string CreatedBy, string LastModifiedBy, int? EmployeeId, int? EmpIncentives, decimal? Times, OutputParameter<int?> Identity, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
    }
}