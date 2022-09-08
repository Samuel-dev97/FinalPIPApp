//using DinkToPdf;
//using DinkToPdf.Contracts;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Server.Data;
//using Server.Features.ReportFeatures.Queries;
//using Server.Utility;
//using Shared.Wrappers;

//namespace Server.Controllers.v1
//{

//    [ApiController]
//    public class FormReportController : BaseApiController
//    {
//        private readonly IWebHostEnvironment _webHostEnvironment;
//        public IConfiguration Configuration { get; }
//        public string ReportToLoad { get; set; } = "FormReport";

//        private IConverter _converter;

//        private readonly PIPContext _context;

//        public FormReportController(PIPContext context, IConfiguration configuration, IWebHostEnvironment WebHostEnvironment, IConverter converter)
//        {
//            Configuration = configuration;
//            _webHostEnvironment = WebHostEnvironment;
//            _converter = converter;
//            this._context = context;
//        }

//        //[HttpGet]
//        //public async Task<IActionResult> FetchAllEmployeesAsync(string Gender, int Status, string StatementType)
//        //{
//        //    Response<object> response = new Response<object>();
//        //    try
//        //    {

//        //        var data = await _context.GetProcedures().GetAllEmployeesReportAsync(Gender, Status, StatementType);

//        //        var globalSettings = new GlobalSettings
//        //        {
//        //            ColorMode = ColorMode.Color,
//        //            Orientation = Orientation.Landscape,
//        //            PaperSize = PaperKind.A4,
//        //            Margins = new MarginSettings { Top = 10 },
//        //            DocumentTitle = "Employees",
//        //        };

//        //        var objectSettings = new ObjectSettings
//        //        {
//        //            PagesCount = true,
//        //            HtmlContent = EmployeesHTML.GetHTMLString(data.ToList()),
//        //            WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
//        //       ///     HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
//        //         //   FooterSettings = { FontName = "Arial", FontSize = 9, Left = $"Total: {data.Count} Records" + "\n" + $"Generated On: {DateTime.Now.ToString("ddd MMM yyyyy")}" }
//        //        };

//        //        var pdf = new HtmlToPdfDocument()
//        //        {
//        //            GlobalSettings = globalSettings,
//        //            Objects = { objectSettings }
//        //        };

//        //        var file = _converter.Convert(pdf);

//        //        response.Succeeded = true;
//        //        response.Message = "Successfuly Generate pdf";
//        //        response.Data = File(file.ToArray(), "application/pdf", $"EmployeesReport_{DateTime.Now.ToString("yyyy-mm-dd")}" + ".pdf");
//        //    }
//        //    catch (Exception ex)
//        //    {

//        //        throw ex;
//        //    }
//        //    return Ok(response);
//        //}

//        [HttpGet]
//        public async Task<IActionResult> Get()
//        {
//            Response<object> response = new Response<object>();

//            try
//            {
//                var data = await _context.EmployeeIncentives.ToListAsync();

//                var globalSettings = new GlobalSettings
//                {
//                    ColorMode = ColorMode.Color,
//                    Orientation = Orientation.Landscape,
//                    PaperSize = PaperKind.A4,
//                    Margins = new MarginSettings { Top = 10 },
//                    DocumentTitle = "PIPForm",
//                };

//                var objectSettings = new ObjectSettings
//                {
//                    PagesCount = true,
//                    HtmlContent = FormHTML.GetHTMLString(data.ToList()),
//                    WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
//                    ///     HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
//                    //   FooterSettings = { FontName = "Arial", FontSize = 9, Left = $"Total: {data.Count} Records" + "\n" + $"Generated On: {DateTime.Now.ToString("ddd MMM yyyyy")}" }
//                };
//                var pdf = new HtmlToPdfDocument()
//                {
//                    GlobalSettings = globalSettings,
//                    Objects = { objectSettings }
//                };


//                var file = _converter.Convert(pdf);

//                response.Succeeded = true;
//                response.Message = "Successfuly Generate pdf";
//                response.Data = File(file.ToArray(), "application/pdf", $"MonthlyPIPReport_{DateTime.Now.ToString("yyyy-mm-dd")}" + ".pdf");
//            }
//            catch (Exception ex)
//            {

//                throw ex;
//            }
//            return Ok(response);
//        }
//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetById(int id)
//        {
//            var sam = await _context.Employees.FirstOrDefaultAsync(a => a.Id == id);
//            return Ok(sam);
//        }

//        [HttpGet("form")]

//        public async Task<IActionResult> GetAll(Enums.Status? status, string? Gender)
//        {
//            return Ok(await Mediator.Send(new GetFormReportQuery { Status = status, Gender = Gender }));
//        }
//    }
//}
