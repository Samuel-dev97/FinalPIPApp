using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Interface;
using Shared.Models.Account;

namespace Server.Controllers
{
    [Authorize]
    [Route("api/identity/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepositoryAsync _repositoryAsync;

        public UserController(IUserRepositoryAsync repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        /// <summary>
        /// Get User Details
        /// </summary>
        /// <returns>Status 200 OK</returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _repositoryAsync.GetAllAsync();
            return Ok(users);
        }

        /// <summary>
        /// Get User By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status 200 OK</returns>
        //[Authorize(Policy = Permissions.Users.View)]
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var user = await _repositoryAsync.GetAsync(id);
            return Ok(user);
        }

        /// <summary>
        /// Register a User
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Status 200 OK</returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
            var origin = Request.Headers["origin"];
            return Ok(await _repositoryAsync.RegisterAsync(request, origin));
        }

        /// <summary>
        /// Toggle User Status (Activate and Deactivate)
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Status 200 OK</returns>
        [Authorize]
        [HttpPost("toggle-status")]
        public async Task<IActionResult> ToggleUserStatusAsync(ToggleUserStatusRequest request)
        {
            return Ok(await _repositoryAsync.ToggleUserStatusAsync(request));
        }

        /// <summary>
        /// Export to Excel
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns>Status 200 OK</returns>
        //[Authorize]
        //[HttpGet("export")]
        //public async Task<IActionResult> Export(string searchString = "")
        //{
        //    var data = await _repositoryAsync.ExportToExcelAsync(searchString);
        //    return Ok(data);
        //}
    }
}
