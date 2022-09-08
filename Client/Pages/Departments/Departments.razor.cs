using AntDesign;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using Shared.Models.Departments;
using Shared.Models.PayGrades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;


namespace Client.Pages.Departments
{
    public partial class Departments
    {
        public List<DepartmentsResponse> departmentsResponses { get; set; } = new List<DepartmentsResponse>();
        public AddEditDepartments AddEditDepartments { get; set; } = new();

        private string error;


        string title = "Add New Department";
        bool _visible = false;
        private Form<AddEditDepartments> form;
        private void OnFinishFailed(EditContext editContext)
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
        private void HandleOk(MouseEventArgs e)
        {
            Console.WriteLine(e);
            _visible = false;
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
    }
}
