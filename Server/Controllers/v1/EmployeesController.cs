
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Ctx;
using Server.Data;
using Server.Models;
using Shared.Models.Employee;
using Shared.Wrappers;


namespace Server.Controllers.v1
{

    public class EmployeesController : BaseApiController
    {
        private readonly ApplicationContext _context;
        private readonly PIPContext _pipContext;

        public EmployeesController(ApplicationContext context, PIPContext pipContext)
        {
            _context = context;
            _pipContext = pipContext;
        }

        [HttpPost]
        public async Task<IActionResult> SavaAsync(AddEditEmployee model)
        {
            var response = new Response<int>();
            var Identity = new OutputParameter<int?>();
            var returnValue = new OutputParameter<int>();
            try
            {
                if (model.Id == 0)
                {
                    var result = await _pipContext.Procedures.EmployeesCREATEAsync( model.EmploymentStatusId, model.City, model.Nationality, model.NAPSA,model.MaritalStatus, model.TerminationDate, model.ConfirmationDate, model.JoinedDate, model.PrivateEmail, model.WorkEmail, model.MobilePhone, model.FirstName, model.LastName, model.MiddleName, model.DOB, model.Gender, model.BasicPay, model.DepartmentId, model.PayGradeId, DateTime.Now, false, DateTime.Now, Identity, returnValue = null);

                    response.Data = (int)Identity.Value;
                    response.Succeeded = true;
                    response.Message = "Successfully Created Employee";
                }
                else
                {
                    var result = await _pipContext.Procedures.EmployeesUPDATEAsync(model.Id,  model.EmploymentStatusId, model.City, model.Nationality, model.NAPSA,model.MaritalStatus, DateTime.Now, DateTime.Now, DateTime.Now, model.PrivateEmail, model.WorkEmail, model.MobilePhone, model.FirstName, model.LastName, model.MiddleName, DateTime.Now, model.Gender, model.BasicPay, model.DepartmentId, model.PayGradeId, DateTime.Now, false, DateTime.Now, Identity, returnValue = null);

                    response.Data = (int)Identity.Value;
                    response.Succeeded = true;
                    response.Message = "Successfully Updated Employee";
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
            var _response = new Response<List<EmployeeResponse>>();
            var _employee = new List<EmployeeResponse>();

            try
            {
                var Identity = new OutputParameter<int?>();
                var returnValue = new OutputParameter<int>();

                var result = await _pipContext.GetProcedures().EmployeesALLAsync();


                foreach (var employees in result)
                {
                    _employee.Add(new EmployeeResponse()
                    {
                        Id = employees.Id,


                        EmploymentStatusId = employees.EmploymentStatusId,

                        City = employees.City,

                        Nationality = employees.Nationality,

                        NAPSA = employees.NAPSA,

                        PayName = employees.PayName,

                       MaritalStatus = employees.MaritalStatus,

                       TerminationDate = employees.TerminationDate,

                        ConfirmationDate = employees.ConfirmationDate,

                        JoinedDate = employees.JoinedDate,

                        PrivateEmail = employees.PrivateEmail,

                        WorkEmail = employees.WorkEmail,

                        MobilePhone = employees.MobilePhone,

                        FirstName = employees.FirstName,

                        LastName = employees.LastName,

                        MiddleName = employees.MiddleName,

                        DOB = employees.DOB,

                        Gender = employees.Gender,

                        BasicPay = employees.BasicPay,

                        DepartmentId = employees.DepartmentId,

                        DeptName = employees.DeptName,

                        FullName = employees.FullName,

                        PayGradeId = employees.PayGradeId,

                        IsDeleted = employees.IsDeleted,

                        CreatedOn = employees.CreatedOn,

                        UpdatedOn = employees.UpdatedOn,



                    });
                }
                _response.Data = _employee;
                _response.Succeeded = true;
                _response.Message = "Employee Data Fetched Successfully";
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
            var _response = new Response<List<EmployeesSINGLEResult>>();
            try
            {
                var Identity = new OutputParameter<int?>();
                var returnValue = new OutputParameter<int>();

                var result = await _pipContext.GetProcedures().EmployeesSINGLEAsync(id);
                _response.Data = result;
                _response.Succeeded = true;
                _response.Message = "Employee Fetched Successfully";
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
            var _response = new Response<List<EmployeesDELETEResult>>();
            try
            {
                var Identity = new OutputParameter<int?>();
                var returnValue = new OutputParameter<int>();

                var result = await _pipContext.GetProcedures().EmployeesDELETEAsync(id);
                _response.Data = result;
                _response.Succeeded = true;
                _response.Message = "Employees Fetched Successfully";
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(_response);
        }*/



    }

}
