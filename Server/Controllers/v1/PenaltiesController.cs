using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Ctx;
using Server.Data;
using Server.Models;
using Shared.Models.Penalties;
using Shared.Wrappers;

namespace Server.Controllers.v1
{
    public class PenaltiesController : BaseApiController
    {
        private readonly ApplicationContext _context;
        private readonly PIPContext _pipContext;

        public PenaltiesController(ApplicationContext context, PIPContext pipContext)
        {
            _context = context;
            _pipContext = pipContext;
        }

        [HttpPost]
        public async Task<IActionResult> SavaAsync(AddEditPenalties model)
        {
            var response = new Response<int>();
            var Identity = new OutputParameter<int?>();
            var returnValue = new OutputParameter<int>();
            try
            {
                if (model.Id == 0)
                {
                    var result = await _pipContext.Procedures.PenaltyCREATEAsync(model.Charge,model.PenaltyName,DateTime.Now, DateTime.Now,model.CreatedBy,model.LastModifiedBy,model.EmployeeId, model.EmpIncentives,model.Times,Identity, returnValue = null);
                   
                    response.Data = (int)Identity.Value;
                    response.Succeeded = true;
                    response.Message = "Successfully Created Departments";
                }
                else
                {
                    var result = await _pipContext.Procedures.PenaltiesUPDATEAsync(model.Id, model.Charge, model.PenaltyName, DateTime.Now, DateTime.Now, model.CreatedBy, model.LastModifiedBy, model.EmployeeId, model.EmpIncentives,model.Times, Identity, returnValue = null);

                    response.Data = (int)Identity.Value;
                    response.Succeeded = true;
                    response.Message = "Successfully Updated Departments";
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
        //  [Authorize]
        public async Task<IActionResult> GetAllAsync()
        {

            var _response = new Response<List<PenaltiesResponse>>();
            var _model = new List<PenaltiesResponse>();

            try
            {
                var Identity = new OutputParameter<int?>();
                var returnValue = new OutputParameter<int>();

                var result = await _pipContext.GetProcedures().PenaltiesALLAsync();


                foreach (var model in result)
                {
                    _model.Add(new PenaltiesResponse()
                    {
                        Id = model.Id,
                    Charge = model.Charge,
                    PenaltyName = model.PenaltyName,
                    CreatedBy = model.CreatedBy,
                    LastModifiedBy = model.LastModifiedBy,


                    CreatedOn = model.CreatedOn,
                    LastModifiedOn = model.LastModifiedOn,
                    EmployeeId = model.EmployeeId,
                    EmpIncentives = model.EmpIncentives,

                });
                }
                _response.Data = _model;
                _response.Succeeded = true;
                _response.Message = "Departments Data Fetched Successfully";
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
        //  [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            var _response = new Response<List<PenaltiesSINGLEResult>>();
            try
            {
                var Identity = new OutputParameter<int?>();
                var returnValue = new OutputParameter<int>();

                var result = await _pipContext.GetProcedures().PenaltiesSINGLEAsync(id);
                _response.Data = result;
                _response.Succeeded = true;
                _response.Message = "Departments Fetched Successfully";
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
            var _response = new Response<List<DepartmentsDELETEResult>>();
            try
            {
                var Identity = new OutputParameter<int?>();
                var returnValue = new OutputParameter<int>();

                var result = await _pipContext.GetProcedures().DepartmentsDELETEAsync(id);
                _response.Data = result;
                _response.Succeeded = true;
                _response.Message = "Departments Fetched Successfully";
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(_response);
        }*/



    }
}
