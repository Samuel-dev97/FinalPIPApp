using AntDesign;
using Client.Models;
using Client.Utilities;
using DinkToPdf;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using Shared.Models.Departments;
using Shared.Models.Employee;
using Shared.Models.PayGrades;
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
using Microsoft.JSInterop;


namespace Client.Pages.Reports
{
    public partial class EmployeeSingle
    {
        public List<DepartmentsResponse> departmentsResponses { get; set; } = new List<DepartmentsResponse>();
        public AddEditDepartments AddEditDepartments { get; set; } = new();

        public List<PayGradeResponse> payGradeResponses { get; set; } = new List<PayGradeResponse>();
        public AddEditPayGrade AddEditPayGrade { get; set; } = new();
        public List<EmployeeResponse> employeeResponses { get; set; } = new List<EmployeeResponse>();
        public AddEditEmployee AddEditEmployee { get; set; } = new();

        private string error;

        string title = "Add New Employee";
        bool _visible = false;
        private Form<AddEditEmployee> form;
        private void OnFinishFailed(EditContext editContext)
        {
            Console.WriteLine($"Failed:{JsonSerializer.Serialize(AddEditEmployee)}");
            error = "Please Check That All Required Are Entered";
            _message.Error(error, 2.5);
        }
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
            await LoadData();
            await LoadData1();
            await LoadData2();
            await base.OnInitializedAsync();
            _loading = false;
        }

        private async Task LoadData()
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
                await LoadData();
                StateHasChanged();
            }
        }
        ///test
        private EditContext EditContext;
        private Comment comment = new Comment();
        private object forecasts;

        protected override void OnInitialized()
        {
            EditContext = new EditContext(comment);


            base.OnInitialized();
        }

        public enum Country
        {
            USA = 1,
            Britain = 2,
            Germany = 3,
            Israel = 4,

        }
        //Nationality
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
        /// Pay Grade

        //protected override async Task OnInitializedAsync()
        //{
        //    _loading = true;
        //    await LoadData1();
        //    await base.OnInitializedAsync();
        //    _loading = false;
        //}

        private async Task LoadData1()
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

        private async Task SaveAsync1()
        {
            var response = await _payGradeServiceAsync.SaveAsync(AddEditPayGrade);
            if (response.Succeeded == true)
            {
                await _message.Loading("Processing Your Request, Please wait...", 2.5)
                .ContinueWith((result) =>
                {
                    _message.Info($"{response.Message}", 2.5);

                });
                _loading = false;
                _visible = false;
                AddEditPayGrade = new();
                await LoadData1();
                StateHasChanged();
            }
        }
        // dept




        private async Task LoadData2()
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
                await LoadData2();
                StateHasChanged();
            }
        }
        //dinToPdf
        public async Task OnFinish()
        {
           
            Response<object> response = new Response<object>();


            //var data = await _context.Employees.ToListAsync();
            var allData = await _reportRepository.GetSingelGuardReportAsync(AddEditEmployee.Id);
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


                _loading = false;

                StateHasChanged();
            }






        }
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



