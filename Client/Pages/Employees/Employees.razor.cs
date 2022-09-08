using AntDesign;
using Client.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using Shared.Models.Departments;
using Shared.Models.Employee;
using Shared.Models.EmployeeIncetives;
using Shared.Models.PayGrades;
using Shared.Models.Penalties;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client.Pages.Employees
{
    public partial class Employees
    {
        public List<PenaltiesResponse> penaltiesResponses { get; set; } = new List<PenaltiesResponse>();
        public AddEditPenalties AddEditPenalties { get; set; } = new();
        public List<EmployeeIncentivesResponse> employeeIncentivesResponses { get; set; } = new List<EmployeeIncentivesResponse>();
        public AddEditEmployeeIncentives AddEditEmployeeIncentives { get; set; } = new();
        public List<DepartmentsResponse> departmentsResponses { get; set; } = new List<DepartmentsResponse>();
        public AddEditDepartments AddEditDepartments { get; set; } = new();
                                                                          
        public List<PayGradeResponse> payGradeResponses { get; set; } = new List<PayGradeResponse>();
        public AddEditPayGrade AddEditPayGrade { get; set; } = new();
        public List<EmployeeResponse> employeeResponses { get; set; } = new List<EmployeeResponse>();
        public AddEditEmployee AddEditEmployee { get; set; } = new();
        //ad
        public List<DepartmentBudgetsResponse> departmentBudgetsResponses { get; set; } = new List<DepartmentBudgetsResponse>();
        public AddEditDepartmentBudgets AddEditDepartmentBudgets { get; set; } = new();
        private string error;
        decimal? _selectedPay;

        string title = "Add New Employee";
        bool _visible = false;
        //private string placement = "left";
        private string placement = "left";

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
        private Form<AddEditEmployee> form;
        private void OnFinishFailed(EditContext editContext)
        {
            Console.WriteLine($"Failed:{JsonSerializer.Serialize(AddEditEmployee)}");
            error = "Please Check That All Required Are Entered";
            _message.Error(error, 2.5);
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
        //void OnSelectedItemChangedHandler()
        //{
        //    AddEditEmployee.BasicPay = AddEditEmployee.MaxSalary;
        //}
        private void OpenModal(int Id = 0)
        {
            if (Id != 0)
            {

                var _single = employeeResponses.Find(x => x.Id == Id);
                title = $"Update Annual Admin Budget";
                AddEditEmployee = new AddEditEmployee(_single);
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
            AddEditEmployee = new();
        }
        bool _loading = false;

        protected override async Task OnInitializedAsync()
        {
            _loading = true;
            await LoadEmployeeData();
            await LoadPayGradeData();
            await LoadDeptData();
            await LoadPenaltiesData();
            await LoadIncentiveData();
            await base.OnInitializedAsync();
            await LoadDeptBudgetData();
            _loading = false;
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

   
        private async Task SaveAsync()
        {
            var response = await _employeeServiceAsync.SaveAsync(AddEditEmployee);

            if (response.Succeeded == true)
            {
                await _message.Loading("Processing Your Request, Please wait...", 2.5)
                .ContinueWith((result) =>
                {
                    _message.Info($"{response.Message}", 2.5);
                 
                });
                _loading = false;
                _visible = false;
                AddEditEmployee = new();
                AddEditDepartments = new();
                AddEditPayGrade = new();
                await LoadEmployeeData();
                await LoadPayGradeData();
                await LoadDeptData();
                StateHasChanged();
            }
        }
        private async Task LoadIncentiveData()
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

        private async Task SaveAsync1()
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
                this.visible1 = false;
                this.visible2 = false;
                AddEditEmployeeIncentives = new();
                await LoadIncentiveData();
                StateHasChanged();
            }
        }
        ///test
        private EditContext EditContext;
        private Comment comment = new Comment();
        private Com com = new Com();
        private Gend gend = new Gend();
        private Marry marry = new Marry();
        private object forecasts;
        
        public PayGradeResponse _selectedPaygrade { get; set; }

        //protected override void OnInitialized()
        //{
        //    EditContext = new EditContext(comment);
        //    EditContext = new EditContext(com);
        //    EditContext = new EditContext(gend);
        //    EditContext = new EditContext(marry);
        //    base.OnInitialized();
        //}
        //Nationality
        public enum Country
        {
            Zambia = 1,
            Zimbambwe =2,
            SA=3,
            Other=4,
        }

        
        //private void OnSelectedItemChangedHandler(PayGradeResponse value)
        //{
        //    payGradeResponses = value?.MaxSalary;
        //    if (payGradeResponses?.Any(x => x.Id == _selectedPay) != true)
        //    {
        //        _selectedPay = payGradeResponses?.FirstOrDefault()?.Id;
        //    }
        //}

        public class Comment
        {
            public string Name { get; set; }
            public Country Country { get; set; }
        }
        ///Status
        public enum Status
        {
            Active = 1,
            NotActive = 2,
        }
        public class Com
        {
            public string Name { get; set; }
            public Status Status { get; set; }
        }
        ///// Gender
        public enum Gender
        {
            Male = 1,
            Female = 2,
        }
        public class Gend
        {
            public string Name { get; set; }
            public Gender Gender { get; set; }
        }
        // marital
        public enum Marital
        {
            Single = 1,
            Married = 2,
            Divorce = 3,
        }
        public class Marry
        {
            public string Name { get; set; }
            public Marital Marital { get; set; }
        }
        /// Pay Grade
        //protected override async Task OnInitializedAsync()
        //{
        //    _loading = true;
        //    await LoadData1();
        //    await base.OnInitializedAsync();
        //    _loading = false;
        //}
        private async Task LoadPayGradeData()
        {
            try
            {
                var response = await _payGradeServiceAsync.GetAllAsync();
                if (response != null && response.Succeeded == true)
                {
                    payGradeResponses = response.Data;
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

      
        //public void open()
        //{
        //    this.visible = true;
        //}
        //public void close()
        //{
        //    this.visible = false;
        //}
        // dept
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
        private async Task SaveAsync2()
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
                await LoadDeptData();
                StateHasChanged();
            }
        }
        //Marital Status
        ////// Data
        public void ExportToPdf()
        {
            int paragraphAfterSpacing = 8;
            int cellMargin = 8;
            PdfDocument pdfDocument = new PdfDocument();
            //Add Page to the PDF document.
            PdfPage page = pdfDocument.Pages.Add();

            //Create a new font.
            PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 16);

            //Create a text element to draw a text in PDF page.
            PdfTextElement title = new PdfTextElement("Weather Forecast", font, PdfBrushes.Black);
           // PdfLayoutResult result = title.Draw(page, new PointF(0, 0));


            PdfStandardFont contentFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
            PdfTextElement content = new PdfTextElement("This component demonstrates fetching data from a client side and Exporting the data to PDF document using Syncfusion .NET PDF library.", contentFont, PdfBrushes.Black);
            PdfLayoutFormat format = new PdfLayoutFormat();
            format.Layout = PdfLayoutType.Paginate;

            //Draw a text to the PDF document.
           // result = content.Draw(page, new RectangleF(0, result.Bounds.Bottom + paragraphAfterSpacing, page.GetClientSize().Width, page.GetClientSize().Height), format);

            //Create a PdfGrid.
            PdfGrid pdfGrid = new PdfGrid();
            pdfGrid.Style.CellPadding.Left = cellMargin;
            pdfGrid.Style.CellPadding.Right = cellMargin;

            //Applying built-in style to the PDF grid
            pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable4Accent1);

            //Assign data source.
            pdfGrid.DataSource = forecasts;

            pdfGrid.Style.Font = contentFont;

            //Draw PDF grid into the PDF page.
           // pdfGrid.Draw(page, new Syncfusion.Drawing.PointF(0, result.Bounds.Bottom + paragraphAfterSpacing));

            MemoryStream memoryStream = new MemoryStream();

            // Save the PDF document.
            pdfDocument.Save(memoryStream);

            // Download the PDF document
            JS.SaveAs("Sample.pdf", memoryStream.ToArray());

        }
    }
}

