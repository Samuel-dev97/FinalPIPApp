using AntDesign;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using Shared.Models.Departments;
using Shared.Models.Employee;
using Shared.Models.EmployeeIncetives;
using Shared.Models.PayGrades;
using Shared.Models.Penalties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Client.Models;
using Client.Utilities;
using Microsoft.JSInterop;
using Client.Services;

namespace Client.Pages.Reports
{
    public partial class Employeesrpt
    {
       
        public List<PenaltiesResponse> penaltiesResponses { get; set; } = new List<PenaltiesResponse>();
        public AddEditPenalties AddEditPenalties { get; set; } = new();
        public List<EmployeeIncentivesResponse> employeeIncentivesResponses { get; set; } = new List<EmployeeIncentivesResponse>();
        public AddEditEmployeeIncentives AddEditEmployeeIncentives { get; set; } = new();

        public List<EmployeeResponse> employeeResponses { get; set; } = new List<EmployeeResponse>();
        public AddEditEmployee AddEditEmployee { get; set; } = new();
        //ad
        public List<DepartmentBudgetsResponse> departmentBudgetsResponses { get; set; } = new List<DepartmentBudgetsResponse>();
        public AddEditDepartmentBudgets AddEditDepartmentBudgets { get; set; } = new();

        private string error;
        private decimal A = 40;
        private decimal B;
        private decimal C;
        private decimal D = 20;
        private decimal E = 30;
        //private decimal Threshold = 110;
        public decimal Threshold;

        private string placement = "left";
        private IHttpService _httpService;

        private bool visible1 = false;
        private bool visible2 = false;
        int wdFirstLayer = 720;
        int wd2ndLayer = 600;

        public void open(int Id = 0)
        {
            if (Id != 0)
            {

                var _single = employeeIncentivesResponses.Find(x => x.Id == Id);
                title = $"Update Annual Admin Budget";
                AddEditEmployeeIncentives = new AddEditEmployeeIncentives(_single);
            }
            //_visible = true; 
            this.visible1 = true;
        }
        void ShowDrawer(int Id = 0)
        {
            if (Id != 0)
            {

                var _single = employeeIncentivesResponses.Find(x => x.Id == Id);
                title = $"Update Annual Admin Budget";
                AddEditEmployeeIncentives = new AddEditEmployeeIncentives(_single);
            }

            this.visible2 = true;
            wdFirstLayer += 260;
        }
        public void close()
        {
            this.visible1 = false;
        }
        void CloseDrawer()
        {
            wdFirstLayer -= 260;
            this.visible2 = false;
        }

        string title = "Add New Employee Incentive";
        bool _visible = false;
        private Form<AddEditEmployeeIncentives> form;
        private void OnFinishFailed(EditContext editContext)
        {
            Console.WriteLine($"Failed:{JsonSerializer.Serialize(AddEditEmployeeIncentives)}");
            error = "Please Check That All Required Are Entered";
            _message.Error(error, 2.5);
        }
        private void OpenModal(int Id = 0)
        {
            if (Id != 0)
            {

                var _single = employeeIncentivesResponses.Find(x => x.Id == Id);
                title = $"Update Annual Admin Budget";
                AddEditEmployeeIncentives = new AddEditEmployeeIncentives(_single);
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
            AddEditEmployeeIncentives = new();
        }
        bool _loading = false;

        protected override async Task OnInitializedAsync()
        {
            _loading = true;
            await LoadData();
            await LoadEmployeeData();
            await LoadPenaltiesData();
            await base.OnInitializedAsync();
            await LoadDeptBudgetData();
            _loading = false;
        }
        private async Task LoadPenaltiesData()
        {
            try
            {
                var response = await _penaltiesServiceAsync.GetAllAsync();
                if (response != null && response.Succeeded == true)
                {
                    penaltiesResponses = response.Data;
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
        private async Task LoadDeptBudgetData()
        {
            try
            {
                var response = await _departmentBudgetsServiceAsync.GetAllAsync();
                if (response != null && response.Succeeded == true)
                {
                    departmentBudgetsResponses = response.Data;
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

        private async Task LoadData()
        {
            try
            {
                var response = await _employeeIncentivesServiceAsync.GetAllAsync();
                if (response != null && response.Succeeded == true)
                {
                    employeeIncentivesResponses = response.Data;
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
        ////ON FINISH
        public async Task OnFinish()
        {
            Response<object> response = new Response<object>();


            //var data = await _context.Employees.ToListAsync();
            var allData = await _reportRepository.GetAllAsync();
            var base64All = allData.Data.FileContents;


            if (allData != null)
            {
                await _jsRuntime.InvokeVoidAsync("Download", new
                {
                    ByteArray = base64All,
                    FileName = $"Employees_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.pdf",
                    MimeType = allData.Data.ContentType
                });

                await _message.Info("Successfully Exported All Employees Report");
                await _employeeIncentivesServiceAsync.DeleteAsync(AddEditEmployeeIncentives.Id);
                // await DeleteContract(int Id);
                //_context.Database.ExecuteSqlRaw("TRUNCATE TABLE [EmployeeIncentives]");

                _loading = false;
               
                StateHasChanged();
            }

        }
        //private async Task RemoveAll()
        //{
          
        //        var response = await _employeeIncentivesServiceAsync.DeleteAsync();
              
        //}
        private async Task DeleteContract(int Id)
        {

            try
            {
                await _employeeIncentivesServiceAsync.DeleteAsync(AddEditEmployeeIncentives.Id);
                await LoadData();

               
                this._loading = false;
               
            }
            catch (Exception ex)
            {
                error = ex.Message;
                _loading = false;
                StateHasChanged();
            }
        }
      
        //calculate
        void Calculate()
        {

            if (AddEditEmployeeIncentives.PIPPayableMonthly > A)
            {
                AddEditEmployeeIncentives.FinalScore = D;
            }
            else
            {
                AddEditEmployeeIncentives.FinalScore = E;
            }
            AddEditEmployeeIncentives.TotalIncentivePayTarget = AddEditEmployeeIncentives.PIPPayableMonthly * AddEditEmployeeIncentives.TotalMonthlyPIP / 100;



            AddEditEmployeeIncentives.Pay = AddEditEmployeeIncentives.TotalMonthlyPIP * AddEditEmployeeIncentives.FinalScore;
        }
        void PenaltyCalculate()
        {

            if (AddEditEmployeeIncentives.PIPPayableMonthly > A)
            {
                AddEditEmployeeIncentives.FinalScore = D - AddEditEmployeeIncentives.PenaltyCharge;
            }
            else
            {
                AddEditEmployeeIncentives.FinalScore = E - AddEditEmployeeIncentives.PenaltyCharge;
            }
            AddEditEmployeeIncentives.TotalIncentivePayTarget = AddEditEmployeeIncentives.PIPPayableMonthly * AddEditEmployeeIncentives.TotalMonthlyPIP / 100;



            AddEditEmployeeIncentives.Pay = AddEditEmployeeIncentives.TotalMonthlyPIP * AddEditEmployeeIncentives.FinalScore;
        }
        private async Task SaveAsync()
        {
            var response = await _employeeIncentivesServiceAsync.SaveAsync(AddEditEmployeeIncentives);
            if (response.Succeeded == true)
            {
                await _message.Loading("Processing Your Request, Please wait...", 2.5)
                .ContinueWith((result) =>
                {
                    _message.Info($"{response.Message}", 2.5);

                });
                _loading = false;
                _visible = false;
                AddEditEmployeeIncentives = new();
                await LoadData();
                StateHasChanged();
            }
        }
    }
}


