
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

namespace Client.Pages.EmployeeIncentivesMonthlies.AddMonthlies
{
    public partial class AddMonthlies
    {

        public List<DepartmentsResponse> departmentsResponses { get; set; } = new List<DepartmentsResponse>();
        public AddEditDepartments AddEditDepartments { get; set; } = new();

        public List<EmployeeIncentiveMonthliesResponse> employeeIncentiveMonthliesResponses { get; set; } = new List<EmployeeIncentiveMonthliesResponse>();
        public AddEditEmployeeIncentiveMonthlies AddEditEmployeeIncentiveMonthlies { get; set; } = new();

        private string error;

        string title = "Add New Department";
        bool _visible = false;
        private Form<AddEditDepartments> form;
        private Form<AddEditEmployeeIncentiveMonthlies> form1;
        private void OnFinishFailed(EditContext editContext)
        {
            Console.WriteLine($"Failed:{JsonSerializer.Serialize(AddEditEmployeeIncentiveMonthlies)}");
            error = "Please Check That All Required Are Entered";
            _message.Error(error, 2.5);
        }
        private void OnFinishFailed1(EditContext editContext)
        {
            Console.WriteLine($"Failed:{JsonSerializer.Serialize(AddEditDepartments)}");
            error = "Please Check That All Required Are Entered";
            _message.Error(error, 2.5);
        }
        private void OpenModal(int Id = 0)
        {
            if (Id != 0)
            {

                var _single = departmentsResponses.Find(x => x.Id == Id);
                title = $"Update Annual Admin Budget";
                AddEditDepartments = new AddEditDepartments(_single);
            }
            _visible = true;
        }
        private void OpenModal1(int Id = 0)
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
        private void HandleOk1(MouseEventArgs e)
        {
            Console.WriteLine(e);
            _visible = false;
        }
        private void HandleCancel1(MouseEventArgs e)
        {
            Console.WriteLine(e);
            _visible = false;
            AddEditEmployeeIncentiveMonthlies = new();
        }
        private void HandleCancel(MouseEventArgs e)
        {
            Console.WriteLine(e);
            _visible = false;
            AddEditDepartments = new();
        }
        bool _loading = false;

        protected override async Task OnInitializedAsync()
        {
            _loading = true;
            await LoadData();
            await base.OnInitializedAsync();
            _loading = false;
        }

        private async Task LoadData()
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

        private async Task SaveAsync()
        {
            var response = await _departmentServiceAsync.SaveAsync(AddEditDepartments);
            if (response.Succeeded == true)
            {
                await _message.Loading("Processing Your Request, Please wait...", 2.5)
                .ContinueWith((result) =>
                {
                    _message.Info($"{response.Message}", 2.5);

                });
                _loading = false;
                _visible = false;
                AddEditDepartments = new();
                await LoadData();
                StateHasChanged();
            }
        }

        /// Calcualte
        public void Calculate()
        {
            AddEditEmployeeIncentiveMonthlies.ExpectedPIPPayable = AddEditEmployeeIncentiveMonthlies.ActualPIPPayable * AddEditEmployeeIncentiveMonthlies.PercentageScore - AddEditEmployeeIncentiveMonthlies.MDPenalty;
        }
        private async Task LoadData1()
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

        private async Task SaveAsync1()
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
