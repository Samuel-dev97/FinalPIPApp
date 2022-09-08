using Shared.Models.Departments;
using Shared.Models.Employee;
using AntDesign;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client.Pages.DepartmentBudgets
{
    public partial class DepartmentBudgets
    {
        public List<DepartmentsResponse> departmentsResponses { get; set; } = new List<DepartmentsResponse>();
        public AddEditDepartments AddEditDepartments { get; set; } = new();

        public List<DepartmentBudgetsResponse> departmentBudgetsResponses { get; set; } = new List<DepartmentBudgetsResponse>();
        public AddEditDepartmentBudgets AddEditDepartmentBudgets { get; set; } = new();

        public List<EmployeeResponse> employeeResponses { get; set; } = new List<EmployeeResponse>();
        public AddEditEmployee AddEditEmployee { get; set; } = new();

        //List<MaritalStatus> _maritalStatus;

        private string error;
        private decimal? YTD;
        private decimal? Margin;
        private decimal? Budget;
        private decimal? results;
        private decimal? percent = 100;
        private decimal? yearz = 12;
        private decimal? month;
        private double? YTDQ1 = 0.25;
        private double? YTDQ2 = 0.5;
        private double? YTDQ3 = 0.75;
        private decimal? YTDQ4 = 1;


        private string placement = "left";

        private bool visible = false;

        string title = "Add New Department Budget";
        bool _visible = false;
        private Form<AddEditDepartmentBudgets> form;
        private void OnFinishFailed(EditContext editContext)
        {
            Console.WriteLine($"Failed:{JsonSerializer.Serialize(AddEditDepartmentBudgets)}");
            error = "Please Check That All Required Are Entered";
            _message.Error(error, 2.5);
        }
        public void open(int Id = 0)
        {
            if (Id != 0)
            {

                var _single = departmentBudgetsResponses.Find(x => x.Id == Id);
                title = $"Update Annual Admin Budget";
                AddEditDepartmentBudgets = new AddEditDepartmentBudgets(_single);
            }
            //_visible = true; 
            this.visible = true;
        }
        public void close()
        {
            this.visible = false;
        }
        private void OpenModal(int Id = 0)
        {
            if (Id != 0)
            {

                var _single = departmentBudgetsResponses.Find(x => x.Id == Id);
                title = $"Update Annual Admin Budget";
                AddEditDepartmentBudgets = new AddEditDepartmentBudgets(_single);
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
            AddEditDepartmentBudgets = new();
        }
        bool _loading = false;

        protected override async Task OnInitializedAsync()
        {
            _loading = true;
            await LoadData();
            await LoadDeptData();
            await base.OnInitializedAsync();
            _loading = false;
        }

        //class MaritalStatus
        //{
        //    public MaritalStatus() { }

        //    public MaritalStatus(MaritalStatus obj)
        //    {
        //        Id = obj.Id;
        //        Name = obj.Name;
        //    }

        //    public int Id { get; set; }
        //    public string Name { get; set; }
        //}
        //public enum Country
        //{
        //    January = 1,
        //    February = 2,
        //    March = 3,
        //    April = 4,
        //    May = 5,
        //    June = 6,
        //    July = 7,
        //    August = 8,
        //    September = 9,
        //    October = 10,
        //    November = 11,
        //    December = 12,
        //}


        //public class Comment
        //{
        //    public string Name { get; set; }
        //    public Country Country { get; set; }
        //}
        private async Task LoadDeptData()
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

        private async Task LoadData()
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

        private async Task SaveAsync()
        {
            var response = await _departmentBudgetsServiceAsync.SaveAsync(AddEditDepartmentBudgets);
            if (response.Succeeded == true)
            {
                await _message.Loading("Processing Your Request, Please wait...", 2.5)
                .ContinueWith((result) =>
                {
                    _message.Info($"{response.Message}", 2.5);
                 
                });
                _loading = false;
                _visible = false;
                this.visible = false;
                AddEditDepartmentBudgets = new();
            
                await LoadData();
                await LoadDeptData();
                StateHasChanged();
            }
        }
        void Calculate()
        {
            //AddEditDepartmentBudgets.ActualBudgetAmount = AddEditDepartmentBudgets.Month / 12 * AddEditDepartmentBudgets.BudgetAmount
            //    - AddEditDepartmentBudgets.GM
            //    / AddEditDepartmentBudgets.BudgetAmount * 100;

            YTD = AddEditDepartmentBudgets.Month / yearz ;
            Margin = AddEditDepartmentBudgets.GM;
            Budget = AddEditDepartmentBudgets.BudgetAmount;


            results = YTD - Margin / Budget ;
            AddEditDepartmentBudgets.PercentegaScore = results * percent;
            AddEditDepartmentBudgets.Q1 = (decimal?)(((double?)AddEditDepartmentBudgets.BudgetAmount) * YTDQ1);
            AddEditDepartmentBudgets.Q2 = (decimal?)(((double?)AddEditDepartmentBudgets.BudgetAmount) * YTDQ2);
            AddEditDepartmentBudgets.Q3 = (decimal?)(((double?)AddEditDepartmentBudgets.BudgetAmount) * YTDQ3);
            AddEditDepartmentBudgets.Q4 = AddEditDepartmentBudgets.BudgetAmount * YTDQ4;

           


        }
        void Calculate1()
        {
            //AddEditDepartmentBudgets.ActualBudgetAmount = AddEditDepartmentBudgets.Month / 12 * AddEditDepartmentBudgets.BudgetAmount
            //    - AddEditDepartmentBudgets.GM
            //    / AddEditDepartmentBudgets.BudgetAmount * 100;

           // YTD = AddEditDepartmentBudgets.Month / yearz;
            //Margin = AddEditDepartmentBudgets.GM;
            //Budget = AddEditDepartmentBudgets.BudgetAmount;


            //results = YTD - Margin / Budget;
           // AddEditDepartmentBudgets.PercentegaScore = results * percent;
            AddEditDepartmentBudgets.Q1 = (decimal?)(((double?)AddEditDepartmentBudgets.BudgetAmount) * YTDQ1);
            AddEditDepartmentBudgets.Q2 = (decimal?)(((double?)AddEditDepartmentBudgets.BudgetAmount) * YTDQ2);
            AddEditDepartmentBudgets.Q3 = (decimal?)(((double?)AddEditDepartmentBudgets.BudgetAmount) * YTDQ3);
            AddEditDepartmentBudgets.Q4 = AddEditDepartmentBudgets.BudgetAmount * YTDQ4;




        }
    }
}
