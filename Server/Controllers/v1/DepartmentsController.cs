using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Ctx;
using Server.Data;
using Server.Models;
using Shared.Models.Departments;
using Shared.Wrappers;

namespace Server.Controllers.v1
{
    
    public class DepartmentsController : BaseApiController
    {
        private readonly ApplicationContext _context;
        private readonly PIPContext _pipContext;

        public DepartmentsController(ApplicationContext context, PIPContext pipContext)
        {
            _context = context;
            _pipContext = pipContext;
        }

        [HttpPost]
        public async Task<IActionResult> SavaAsync(AddEditDepartments model)
        {
            var response = new Response<int>();
            var Identity = new OutputParameter<int?>();
            var returnValue = new OutputParameter<int>();
            try
            {
                if (model.Id == 0)
                {
                    var result = await _pipContext.Procedures.DepartmentsCREATEAsync(model.DeptName, model.Code, model.Description, model.Specification, false, DateTime.Now, DateTime.Now,model.logo,model.Score,Identity, returnValue = null);

                    response.Data = (int)Identity.Value;
                    response.Succeeded = true;
                    response.Message = "Successfully Created Departments";
                }
                else
                {
                    var result = await _pipContext.Procedures.DepartmentsUPDATEAsync(model.Id, model.DeptName, model.Code, model.Description, model.Specification, false, DateTime.Now, DateTime.Now,model.logo,model.Score, Identity, returnValue = null);

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

            var _response = new Response<List<DepartmentsResponse>>();
            var _department = new List<DepartmentsResponse>();

            try
            {
                var Identity = new OutputParameter<int?>();
                var returnValue = new OutputParameter<int>();

                var result = await _pipContext.GetProcedures().DepartmentsALLAsync();


                foreach (var department in result)
                {
                    _department.Add(new DepartmentsResponse()
                    {
                        Id = department.Id,
                        DeptName = department.DeptName,
                        Code = department.Code,

                        Description = department.Description,
                        Specification = department.Specification,
                        CreatedOn = department.CreatedOn,
                        UpdatedOn = department.UpdatedOn,
                        logo = department.logo,
                        IsDeleted = department.IsDeleted,

                    });
                }
                _response.Data = _department;
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
            var _response = new Response<List<DepartmentsSINGLEResult>>();
            try
            {
                var Identity = new OutputParameter<int?>();
                var returnValue = new OutputParameter<int>();

                var result = await _pipContext.GetProcedures().DepartmentsSINGLEAsync(id);
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
