using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Ctx;
using Server.Data;
using Shared.Models.PayGrades;
using Shared.Wrappers;

namespace Server.Controllers.v1
{
    public class PayGradeController : BaseApiController
    {
        private readonly ApplicationContext _context;
        private readonly PIPContext _pipContext;
        public PayGradeController(ApplicationContext context, PIPContext pipContext)
        {
            _context = context;
            _pipContext = pipContext;
        }

        [HttpPost]
        public async Task<IActionResult> SavaAsync(AddEditPayGrade model)
        {
            var response = new Response<int>();
            var Identity = new OutputParameter<int?>();
            var returnValue = new OutputParameter<int>();
            try
            {
                if(model.Id == 0)
                {
                    var result = await _pipContext.Procedures.PayGradesCREATEAsync(model.Name, model.MaxSalary, model.MinSalary, DateTime.Now, false, DateTime.Now,model.Monthly,model.Description,Identity, returnValue = null);

                    response.Data = (int)Identity.Value;
                    response.Succeeded = true;
                    response.Message = "Successfully Created Pay Grade";
                }
                else
                {
                    var result = await _pipContext.Procedures.PayGradesUPDATEAsync(model.Id, model.Name, model.MaxSalary, model.MinSalary,model.Monthly,model.Description, false, Identity, returnValue = null);

                    response.Data = (int)Identity.Value;
                    response.Succeeded = true;
                    response.Message = "Successfully Updated Pay Grade";
                }
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
                response.Errors.Add(ex.InnerException.Message);
                response.Succeeded = false;
                response.Message = "Could Not Process Your Request, Pleaase Contact Administratot";
                response.Data = 0;
                throw;
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = new Response<List<PayGradeResponse>>();
            var _paygrades = new List<PayGradeResponse>();
            try
            {
                 var result = await _pipContext.GetProcedures().PayGradesALLAsync();
                foreach (var x in result)
                {
                    _paygrades.Add(new PayGradeResponse()
                    {
                        Id = x.Id,
                        Name = x.PayName,
                        MaxSalary = x.MaxSalary,
                        MinSalary = x.MinSalary,
                        CreatedOn = x.CreatedOn,
                        IsDeleted = x.IsDeleted,
                        UpdatedOn = x.UpdatedOn,
                        Monthly = x.Monthly,
                        Description = x.Description,
                    });
                }

                response.Data = _paygrades;
                response.Succeeded = true;
                response.Message = "Successfully fetch Pay Grade Data";
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
                response.Errors.Add(ex.InnerException.Message);
                response.Succeeded = false;
                response.Message = "Could Not Process Your Request, Pleaase Contact Administratot";
                response.Data = null;
                throw;
            }

            return Ok(response);
        }
    }
}
