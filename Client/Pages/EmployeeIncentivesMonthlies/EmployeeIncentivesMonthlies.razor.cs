
using System.Collections.Generic;
using AntDesign;
using Shared.Models.EmployeeIncentiveMonthlies;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using System;

using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Shared.Models.Departments;
using Shared.Models.Employee;
using Shared.Models.EmployeeIncetives;

namespace Client.Pages.EmployeeIncentivesMonthlies
{
    public partial class EmployeeIncentivesMonthlies
    {
        public List<DepartmentsResponse> departmentsResponses { get; set; } = new List<DepartmentsResponse>();
        public AddEditDepartments AddEditDepartments { get; set; } = new();

        public List<EmployeeResponse> employeeResponses { get; set; } = new List<EmployeeResponse>();

        public List<EmployeeIncentivesResponse> EmployeeIncentives { get; set; } = new List<EmployeeIncentivesResponse>();

        public List<EmployeeIncentiveMonthliesResponse> employeeIncentiveMonthliesResponses { get; set; } = new List<EmployeeIncentiveMonthliesResponse>();
        public AddEditEmployeeIncentiveMonthlies AddEditEmployeeIncentiveMonthlies { get; set; } = new();

        private string error;

        string title = "Add New Employee Incentive";
        bool _visible = false;
        private Form<AddEditEmployeeIncentiveMonthlies> form;
        private void OnFinishFailed(EditContext editContext)
        {
            Console.WriteLine($"Failed:{JsonSerializer.Serialize(AddEditEmployeeIncentiveMonthlies)}");
            error = "Please Check That All Required Are Entered";
            _message.Error(error, 2.5);
        }
        private void OpenModal(int Id = 0)
        {
            if (Id != 0)
            {

                var _single = employeeIncentiveMonthliesResponses.Find(x => x.Id == Id);
                title = $"Update Annual Admin Budget";
                AddEditEmployeeIncentiveMonthlies = new AddEditEmployeeIncentiveMonthlies(_single);
            }
            _visible = true;
        }
        private void HandleOk(MouseEventArgs e)
        {
            Console.WriteLine(e);
            _visible = false;
        }

        private void HandleCancel(MouseEventArgs e)
        {
            Console.WriteLine(e);
            _visible = false;
            AddEditEmployeeIncentiveMonthlies = new();
        }
        bool _loading = false;

        void Calculate()
        {
            AddEditEmployeeIncentiveMonthlies.ExpectedPIPPayable = AddEditEmployeeIncentiveMonthlies.ActualPIPPayable * AddEditEmployeeIncentiveMonthlies.PercentageScore  /100  - AddEditEmployeeIncentiveMonthlies.MDPenalty;
        }
        protected override async Task OnInitializedAsync()
        {
            _loading = true;
            await LoadData();
            await LoadDepartmentData();
            await LoadEmployeeData();
            await LoadEmployeeIncentiveData();
            await base.OnInitializedAsync();
            _loading = false;
        }

      
        private async Task LoadData()
        {
            try
            {
                var response = await _employeeIncentiveMonthliesServiceAsync.GetAllAsync();
                if (response != null && response.Succeeded == true)
                {
                    employeeIncentiveMonthliesResponses = response.Data;
                    await _message.Info(response.Message);
                }
                else
                {
                    await _message.Error(response.Message);
                }
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        private async Task LoadEmployeeIncentiveData()
        {
            try
            {
                var response = await _employeeIncentivesServiceAsync.GetAllAsync();
                if (response != null && response.Succeeded == true)
                {
                    EmployeeIncentives = response.Data;
                    await _message.Info(response.Message);
                }
                else
                {
                    await _message.Error(response.Message);
                }
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        //private async Task SaveAsync()
        //{
        //    var response = await _employeeIncentiveMonthliesServiceAsync.SaveAsync(AddEditEmployeeIncentiveMonthlies);
        //    if (response.Succeeded == true)
        //    {
        //        await _message.Loading("Processing Your Request, Please wait...", 2.5)
        //        .ContinueWith((result) =>
        //        {
        //            _message.Info($"{response.Message}", 2.5);

        //        });
        //        _loading = false;
        //        _visible = false;
        //        AddEditEmployeeIncentiveMonthlies = new();
        //        await LoadData();
        //       // await LoadData2();
        //        StateHasChanged();
        //    }
        //}
        /// dept

        private async Task LoadDepartmentData()
        {
            try
            {
                var response = await _departmentServiceAsync.GetAllAsync();
                if (response != null && response.Succeeded == true)
                {
                    departmentsResponses = response.Data;
                    await _message.Info(response.Message);
                }
                else
                {
                    await _message.Error(response.Message);
                }
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        private async Task LoadEmployeeData()
        {
            try
            {
                var response = await _employeeServiceAsync.GetAllAsync();
                if (response != null && response.Succeeded == true)
                {
                    employeeResponses = response.Data;
                    await _message.Info(response.Message);
                }
                else
                {
                    await _message.Error(response.Message);
                }
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }


        private async Task SaveAsnyc()
        {
            var response = await _employeeIncentiveMonthliesServiceAsync.SaveAsync(AddEditEmployeeIncentiveMonthlies);
            if (response.Succeeded == true)
            {
                await _message.Loading("Processing Your Request, Please wait...", 2.5)
                .ContinueWith((result) =>
                {
                    _message.Info($"{response.Message}", 2.5);

                });
                _loading = false;
                _visible = false;
                AddEditEmployeeIncentiveMonthlies = new();
                await LoadData();
                StateHasChanged();
            }
        }
    }
}
