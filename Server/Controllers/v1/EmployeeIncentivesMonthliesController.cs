using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using Server.Ctx;
using Server.Data;
using Server.Models;

using Shared.Wrappers;

using Shared.Models.EmployeeIncentiveMonthlies;
using Microsoft.AspNetCore.Authorization;

namespace Server.Controllers.v1
{
   
    
    public class EmployeeIncentivesMonthliesController : BaseApiController
    {
        private readonly ApplicationContext _context;
        private readonly PIPContext _pipContext;

        public EmployeeIncentivesMonthliesController(ApplicationContext context, PIPContext pipContext)
        {
            _context = context;
            _pipContext = pipContext;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SavaAsync(AddEditEmployeeIncentiveMonthlies model)
        {
            var response = new Response<int>();
            var Identity = new OutputParameter<int?>();
            var returnValue = new OutputParameter<int>();
            try
            {
                if (model.Id == 0)
                {
                    var result = await _pipContext.Procedures.EmployeeIncentiveMonthliesCREATEAsync(model.ExpectedPIPPayable, model.ActualPIPPayable, model.MDPenalty, model.PercentageScore, model.Month, model.EmployeeId, model.DepartmentId, model.FirstAuthorizer, model.SecondAuthorizer, model.ThirdAuthorizer, false,  Identity, returnValue = null);

                    response.Data = (int)Identity.Value;
                    response.Succeeded = true;
                    response.Message = "Successfully Created Employee Incentive Monthlies";
                }
                else
                {
                    var result = await _pipContext.Procedures.EmployeeIncentiveMonthliesUPDATEAsync(model.Id, model.ExpectedPIPPayable, model.ActualPIPPayable, model.MDPenalty, model.PercentageScore, model.Month, model.EmployeeId, model.DepartmentId, model.FirstAuthorizer, model.SecondAuthorizer, model.ThirdAuthorizer, false,  Identity, returnValue = null);

                    response.Data = (int)Identity.Value;
                    response.Succeeded = true;
                    response.Message = "Successfully Updated Employee Incentive Monthlies";
                }
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
                response.Errors.Add(ex.InnerException.Message);
                response.Succeeded = false;
                response.Message = "Could Not Process Your Request, Please Contact Administrator";
                response.Data = 0;
                throw;
            }

            return Ok(response);
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllAsync()
        {
            var _response = new Response<List<EmployeeIncentiveMonthliesResponse>>();
            var _employeeIncentiveMonthly = new List<EmployeeIncentiveMonthliesResponse>();
            try
            {


                var result = await _pipContext.GetProcedures().EmployeeIncentiveMonthliesALLAsync();
                foreach (var employeeIncentivesMonthly in result)
                {
                    _employeeIncentiveMonthly.Add(new EmployeeIncentiveMonthliesResponse()
                    {
                        Id = employeeIncentivesMonthly.Id,

                        ExpectedPIPPayable = employeeIncentivesMonthly.ExpectedPIPPayable,

                        ActualPIPPayable = employeeIncentivesMonthly.ActualPIPPayable,

                        MDPenalty = employeeIncentivesMonthly.MDPenalty,

                        PercentageScore = employeeIncentivesMonthly.PercentageScore,

                        Month = employeeIncentivesMonthly.Month,
                        DeptName = employeeIncentivesMonthly.DeptName,
                        EmployeeId = employeeIncentivesMonthly.EmployeeId,

                        DepartmentId = employeeIncentivesMonthly.DepartmentId,

                        FirstAuthorizer = employeeIncentivesMonthly.FirstAuthorizer,

                        SecondAuthorizer = employeeIncentivesMonthly.SecondAuthorizer,

                        ThirdAuthorizer = employeeIncentivesMonthly.ThirdAuthorizer,

                        IsDeleted = employeeIncentivesMonthly.IsDeleted,

                        CreatedOn = employeeIncentivesMonthly.CreatedOn,
                        //
                        //FirstName = employeeIncentivesMonthly.FirstName,

                        //LastName = employeeIncentivesMonthly.LastName,

                        UpdatedOn = employeeIncentivesMonthly.UpdatedOn,
                    });
                }


                _response.Data = _employeeIncentiveMonthly;
                _response.Succeeded = true;
                _response.Message = "Monthly Employee Incentives  Data Fetched Successfully";
            }
            catch (Exception ex)
            {

                _response.Errors.Add(ex.Message);
                _response.Errors.Add(ex.InnerException.Message);
                _response.Succeeded = false;
                _response.Message = "Could Not Process Your Request, Please Contact Administrator";
                _response.Data = null;
                throw;
            }
            return Ok(_response);
        }


        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            var _response = new Response<List<EmployeeIncentiveMonthliesSINGLEResult>>();
            try
            {
                var Identity = new OutputParameter<int?>();
                var returnValue = new OutputParameter<int>();

                var result = await _pipContext.GetProcedures().EmployeeIncentiveMonthliesSINGLEAsync(id);
                _response.Data = result;
                _response.Succeeded = true;
                _response.Message = "Employee Incentives Fetched Successfully";
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(_response);
        }

        /*[HttpDelete("{id}")]
        //  [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var _response = new Response<List<EmployeeIncentiveMonthliesDELETEResult>>();
            try
            {
                var Identity = new OutputParameter<int?>();
                var returnValue = new OutputParameter<int>();

                var result = await _pipContext.GetProcedures().EmployeeIncentiveMonthliesDELETEAsync(id);
                _response.Data = result;
                _response.Succeeded = true;
                _response.Message = "Employee Incentive Monthlies  Fetched Successfully";
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(_response);
        }*/



    }
}
