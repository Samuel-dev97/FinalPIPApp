using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Ctx;
using Server.Data;
using Server.Models;
using Shared.Models.EmployeeIncetives;
using Shared.Wrappers;
using System.Linq;

namespace Server.Controllers.v1
{
    public class EmployeeIncentivesController : BaseApiController
    {
        private readonly ApplicationContext _context;
        private readonly PIPContext _pipContext;
        public EmployeeIncentivesController(ApplicationContext context, PIPContext pipContext)
        {
            _context = context;
            _pipContext = pipContext;
        }

        [HttpPost]
        public async Task<IActionResult> SavaAsync(AddEditEmployeeIncentives model)
        {
            var response = new Response<int>();
            var Identity = new OutputParameter<int?>();
            var returnValue = new OutputParameter<int>();
            try
            {
                if (model.Id == 0)
                {
                    var result = await _pipContext.Procedures.EmployeeIncentivesCREATEAsync(model.TotalIncentivePayTarget, model.TotalPayableYearEnd, model.TotalMonthlyPIP, model.PIPPayableMonthly, true, model.EmployeeId, false,DateTime.Now, DateTime.Now,model.BudgetId, model.FinalScore, model.Pay,model.PenaltyCharge,model.Month,model.Date,model.FirstAuth,model.SecondAuth,model.ThirdAuth,model.Comment1,model.Comment2,model.Comment3,model.ForeName = model.FullName,model.PenaltyName,Identity, returnValue = null);

                    response.Data = (int)Identity.Value;
                    response.Succeeded = true;
                    response.Message = "Successfully Created Pay Grade";
                }
                else
                {
                    var result = await _pipContext.Procedures.EmployeeIncentivesUPDATEAsync(model.Id, model.TotalIncentivePayTarget, model.TotalPayableYearEnd, model.TotalMonthlyPIP, model.PIPPayableMonthly, true, model.EmployeeId, DateTime.Now, false,DateTime.Now,model.BudgetId,model.FinalScore,model.Pay,model.PenaltyCharge,model.Month,model.Date, model.FirstAuth, model.SecondAuth, model.ThirdAuth, model.Comment1, model.Comment2, model.Comment3, model.ForeName = model.FullName, model.PenaltyName, Identity, returnValue = null);


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
            var response = new Response<List<EmployeeIncentivesResponse>>();
            var _employeeIncentives = new List<EmployeeIncentivesResponse>();
            try
            {
                var result = await _pipContext.GetProcedures().EmployeeIncentivesALLAsync();
                foreach (var x in result)
                {
                    _employeeIncentives.Add(new EmployeeIncentivesResponse()
                    {
                        Id = x.Id,
                        TotalIncentivePayTarget = x.TotalIncentivePayTarget,
                        TotalPayableYearEnd = x.TotalPayableYearEnd,
                        TotalMonthlyPIP = x.TotalMonthlyPIP,
                        PIPPayableMonthly = x.PIPPayableMonthly,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                         EmployeeId = x.EmployeeId,
                        //IsCurrent = x.IsCurrent,
                        //IsCurrent = x.IsCurrent,
                        FinalScore = x.FinalScore,
                        Pay = x.Pay,
                        PenaltyCharge = x.PenaltyCharge,
                        Month = x.Month,
                        Date = x.Date,
                        FullName = x.FullName,
                        FirstAuth = x.FirstAuth,
                    SecondAuth = x.SecondAuth,
                    ThirdAuth = x.ThirdAuth,
                    Comment1 = x.Comment1,
                    Comment2 = x.Comment2,
                    Comment3 = x.Comment3,
                    ForeName = x.ForeName,
                    PenaltyName = x.PenaltyName,
                        IsDeleted = x.IsDeleted,
                        CreatedOn = x.CreatedOn,
                        UpdatedOn = x.UpdatedOn,
                    });
                }

                response.Data = _employeeIncentives;
                response.Succeeded = true;
                response.Message = "Successfully fetch Pay Grade Data";
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
                response.Errors.Add(ex.InnerException.Message);
                response.Succeeded = false;
                response.Message = "Could Not Process Your Request, Pleaase Contact Administrator";
                response.Data = null;
                throw;
            }

            return Ok(response);
        }


        [HttpDelete("{id}")]
        public void DeleteAllAsync()
        {
   
                _context.Database.ExecuteSqlRaw("TRUNCATE TABLE [EmployeeIncentives]");

        }
        //[HttpDelete("{id}")]
        ////[Authorize]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    return Ok(await Mediator.Send(new DeleteGuardByIdCommand { Id = id }));
        //}
        //[HttpDelete("{id}")]
        //public async Task<EmployeeIncentives> Delete(Guid id)

        //{

        //    var delete = await _context.EmployeeIncentives.FindAsync(id);
        //    if(delete != null)
        //    {
        //        _context.EmployeeIncentives.Remove(delete);
        //        await _context.SaveChangesAsync();
        //    }
        //    return delete;


        //}
    }
}
