//using AntDesign;
//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Components.Authorization;

//using Client.DTOs;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;
//using System.Threading.Tasks;
//using Shared.Models.Penalties;
//using Shared.Models.EmployeeIncetives;
//using Shared.Models.Employee;
//using Shared.Models.Departments;

//namespace Client.Pages
//{
//    public partial class Index
//    {
//        private List<PenaltiesResponse> penaltiesCount { get; set; } = new List<PenaltiesResponse>();
//        public AddEditPenalties AddEditPenalties { get; set; } = new();
//        private List<EmployeeIncentivesResponse> employeeIncentivesCount { get; set; } = new List<EmployeeIncentivesResponse>();
//        public AddEditEmployeeIncentives AddEditEmployeeIncentives { get; set; } = new();
//        public List<DepartmentsResponse> departmentsCount { get; set; } = new List<DepartmentsResponse>();
//        public AddEditDepartments AddEditDepartments { get; set; } = new();
//        public List<EmployeeResponse> employeeResponses { get; set; } = new List<EmployeeResponse>();
//        public AddEditEmployee AddEditEmployee { get; set; } = new();
//        //ad
//        public List<DepartmentBudgetsResponse> departmentBudgetsCount { get; set; } = new List<DepartmentBudgetsResponse>();
//        public AddEditDepartmentBudgets AddEditDepartmentBudgets { get; set; } = new();


//        int EmployeeCount { get; set; }
       


//        bool _loading = false;

//        protected override async Task OnInitializedAsync()
//        {
//            //var state = await _authProvider.GetAuthenticationStateAsync();
//            //if (state == new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())))
//            //{
//            //    _navigationManager.NavigateTo("/login");
//            //}

//            LocationData = new List<LocationViewModel>();
//            TownData = new List<TownViewModel>();
//            CompanyData = new List<CompanyViewModel>();
//            ShiftData = new List<ShiftViewModel>();
//            TurnData = new List<TurnViewModel>();
//            await LoadData();
//        }
//        //private async Task LoadPenaltiesData()
//        //{
//        //    try
//        //    {
//        //        var response = await _penaltiesServiceAsync.GetAllAsync();
//        //        if (response != null && response.Succeeded == true)
//        //        {
//        //            penaltiesResponses = response.Data;
//        //            await _message.Info(response.Message);
//        //        }
//        //        else
//        //        {
//        //            await _message.Error(response.Message);
//        //        }
//        //    }
//        //    catch (System.Exception ex)
//        //    {

//        //        throw;
//        //    }
//        //}
//        private async Task LoadEmployeeData()
//        {
//            try
//            {
//                var response = await _employeeServiceAsync.GetAllAsync();
//                if (response != null && response.Succeeded == true)
//                {
//                    employeeResponses = response.Data;
//                    await _message.Info(response.Message);
//                }
//                else
//                {
//                    await _message.Error(response.Message);
//                }
//            }
//            catch (System.Exception ex)
//            {

//                throw;
//            }
//        }
//        //private async Task LoadDeptBudgetData()
//        //{
//        //    try
//        //    {
//        //        var response = await _departmentBudgetsServiceAsync.GetAllAsync();
//        //        if (response != null && response.Succeeded == true)
//        //        {
//        //            departmentBudgetsResponses = response.Data;
//        //            await _message.Info(response.Message);
//        //        }
//        //        else
//        //        {
//        //            await _message.Error(response.Message);
//        //        }
//        //    }
//        //    catch (System.Exception ex)
//        //    {

//        //        throw;
//        //    }
//        //}

//        //private async Task LoadEmployeeIncentivesData()
//        //{
//        //    try
//        //    {
//        //        var response = await _employeeIncentivesServiceAsync.GetAllAsync();
//        //        if (response != null && response.Succeeded == true)
//        //        {
//        //            employeeIncentivesResponses = response.Data;
//        //            await _message.Info(response.Message);
//        //        }
//        //        else
//        //        {
//        //            await _message.Error(response.Message);
//        //        }
//        //    }
//        //    catch (System.Exception ex)
//        //    {

//        //        throw;
//        //    }
//        //}

//        string Email { get; set; }

//        //private async Task LoadDataAsync()
//        //{
//        //    var state = await _authProvider.GetAuthenticationStateAsync();
//        //    var user = state.User;
//        //    if (user == null) return;
//        //    if (user.Identity?.IsAuthenticated == true)
//        //    {
//        //        Email = user.GetEmail();
//        //        await MessageDisplay(Email);
//        //    }
//        //}

//        //private async Task MessageDisplay(string email)
//        //{
//        //    await _message.Loading("Authenticating user..", 2.5)
//        //      .ContinueWith((result) =>
//        //      {
//        //          _message.Info($"Welcome! {email}", 2.5);
//        //      });
//        //}

//        //private async Task LoadData()
//        //{
//        //    _loading = true;
//        //    await LoadCompanyData();
//        //    await LoadLocationData();
//        //    await LoadTownData();
//        //    await LoadGuardData();
//        //    await LoadTurnData();
//        //    await LoadShiftData();
//        //    _loading = false;
//        //}

//        //private async Task LoadShiftData()
//        //{
//        //    _loading = true;
//        //    try
//        //    {
//        //        var response = await _shiftRepository.GetAllAsync();
//        //        ShiftData = response.Data;
//        //        _loading = false;
//        //        StateHasChanged();
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        _loading = false;
//        //        throw ex;
//        //    }
//        //}

//        //private async Task LoadTurnData()
//        //{

//        //    try
//        //    {
//        //        var response = await _turnRepository.GetAllAsync();
//        //        TurnData = response.Data;

//        //        StateHasChanged();
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        _loading = false;
//        //        throw ex;
//        //    }
//        //}

//        //private async Task LoadLocationData()
//        //{
//        //    try
//        //    {
//        //        var response = await _locationRepository.GetAllAsync();
//        //        LocationData = response.Data;
//        //        locationCount = LocationData.Count();
//        //        StateHasChanged();
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        throw ex;
//        //    }
//        //}

//        //private async Task LoadTownData()
//        //{
//        //    try
//        //    {
//        //        var response = await _townRepository.GetAllAsync();
//        //        TownData = response.Data;
//        //        townCount = TownData.Count();
//        //        StateHasChanged();
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        throw ex;
//        //    }
//        //}

//        //private async Task LoadCompanyData()
//        //{
//        //    try
//        //    {
//        //        var response = await _companyRepository.GetAllAsync();
//        //        CompanyData = response.Data;
//        //        companyCount = CompanyData.Count();
//        //        StateHasChanged();
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        throw ex;
//        //    }
//        //}

//        //private async Task LoadGuardData()
//        //{
//        //    try
//        //    {
//        //        var response = await _guardRepository.GetAllAsync();
//        //        GuardData = response.Data;
//        //        guardCount = GuardData.Count();
//        //        StateHasChanged();
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        throw ex;
//        //    }
//        //}
//    }
//}
