using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Ctx;
using Server.Ctx.Enum;
using Server.Data;
using Server.Models;
using Shared.Models.Departments;
using Shared.Wrappers;


namespace Server.Controllers.v1
{
    public class DepartmentBudgetsController : BaseApiController
    {
        private readonly ApplicationContext _context;
        private readonly PIPContext _pipContext;

        public DepartmentBudgetsController(ApplicationContext context, PIPContext pipContext)
        {
            _context = context;
            _pipContext = pipContext;
        }

      
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SavaAsync(AddEditDepartmentBudgets model)
        {
            var response = new Response<int>();
            var Identity = new OutputParameter<int?>();
            var returnValue = new OutputParameter<int>();
            try
            {
                if (model.Id == 0)
                {
                    var result = await _pipContext.Procedures.DepartmentBudgetsCREATEAsync(model.DepartmentId, model.BudgetAmount, model.ActualBudgetAmount, model.Q1, model.Q2, model.Q3, model.Q4, model.PercentegaScore, model.Year, DateTime.Now, DateTime.Now, false, true,model.GM,model.Month,model.Date, Identity, returnValue = null);

                    response.Data = (int)Identity.Value;
                    response.Succeeded = true;
                    response.Message = "Successfully Created Department Budgets";
                }
                else
                {
                    var result = await _pipContext.Procedures.DepartmentBudgetsUPDATEAsync(model.Id, model.DepartmentId, model.BudgetAmount, model.ActualBudgetAmount, model.Q1, model.Q2, model.Q3, model.Q4, model.PercentegaScore, model.Year, DateTime.Now, DateTime.Now, false, true, model.GM, model.Month,model.Date, Identity, returnValue = null);

                    response.Data = (int)Identity.Value;
                    response.Succeeded = true;
                    response.Message = "Successfully Updated Department Budgets";
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

        //[Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllAsync()
        {
            var _response = new Response<List<DepartmentBudgetsResponse>>();
            var _departmentBudgets = new List<DepartmentBudgetsResponse>();
            try
            {
                var Identity = new OutputParameter<int?>();
                var returnValue = new OutputParameter<int>();

                var result = await _pipContext.GetProcedures().DepartmentBudgetsALLAsync();
                foreach(var departmentBudget in result)
                {
                    _departmentBudgets.Add(new DepartmentBudgetsResponse()
                    {
                        Id = departmentBudget.Id,
                        DepartmentId = departmentBudget.DepartmentId,
                        DeptName = departmentBudget.DeptName,
                        IsDeleted = departmentBudget.IsDeleted,
                        ActualBudgetAmount = departmentBudget.ActualBudgetAmount,
                        BudgetAmount = departmentBudget.ActualBudgetAmount,
                        PercentegaScore = departmentBudget.PercentegaScore,
                        CreatedOn = departmentBudget.CreatedOn,
                        IsCurrent  = departmentBudget.IsCurrent,
                        Q1 = departmentBudget.Q1,
                        Q2 = departmentBudget.Q2,
                        Q3 = departmentBudget.Q3,
                        Q4 = departmentBudget.Q4,
                        UpdatedOn = departmentBudget.UpdatedOn,
                        Year = departmentBudget.Year,
                        GM = departmentBudget.GM,
                        Month = departmentBudget.Month,
                        Date = departmentBudget.Date,
                    });
                }


                _response.Data = _departmentBudgets;
                _response.Succeeded = true;
                _response.Message = "Department Budgets Data Fetched Successfully";
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
            var _response = new Response<List<DepartmentBudgetsSINGLEResult>>();
            try
            {
                var Identity = new OutputParameter<int?>();
                var returnValue = new OutputParameter<int>();

                var result = await _pipContext.GetProcedures().DepartmentBudgetsSINGLEAsync(id);
                _response.Data = result;
                _response.Succeeded = true;
                _response.Message = "Department BUdgets Fetched Successfully";
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
            var _response = new Response<List<DepartmentBudgetsDELETEResult>>();
            try
            {
                var Identity = new OutputParameter<int?>();
                var returnValue = new OutputParameter<int>();

                var result = await _pipContext.GetProcedures().DepartmentBudgetsDELETEAsync(id);
                _response.Data = result;
                _response.Succeeded = true;
                _response.Message = "Department Budgets Fetched Successfully";
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(_response);
        }*/

    }
}
