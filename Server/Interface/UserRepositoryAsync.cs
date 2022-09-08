using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Server.Ctx.Enum;
using Server.Ctx.Models.Identity;
using Server.Exceptions;
using Server.Extensions;
using Shared.Wrappers;
using Shared.Models.Account;
using System.Globalization;

namespace Server.Interface
{
    public interface IUserRepositoryAsync
    {
        Task<Response<string>> RegisterAsync(RegisterRequest request, string origin);
        Task<Response<string>> ToggleUserStatusAsync(ToggleUserStatusRequest request);
        Task<int> GetCountAsync();
        Task<Response<List<AccountResponse>>> GetAllAsync();
        Task<Response<AccountResponse>> GetAsync(string userId);
    }
    public class UserRepositoryAsync : IUserRepositoryAsync
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JWTSettings _jwtSettings;
        private readonly IExcelRepositoryAsync _excelRepositoryAsync;
        private readonly IDateTimeService _dateTimeService;
        private readonly IMapper _mapper;
        public UserRepositoryAsync(UserManager<ApplicationUser> userManager,
          RoleManager<IdentityRole> roleManager,
          IOptions<JWTSettings> jwtSettings,
          IDateTimeService dateTimeService,
             IExcelRepositoryAsync excelRepositoryAsync,
          SignInManager<ApplicationUser> signInManager,
           IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtSettings = jwtSettings.Value;
            _dateTimeService = dateTimeService;
            _signInManager = signInManager;
            _mapper = mapper;
            _excelRepositoryAsync = excelRepositoryAsync;
        }

        public async Task<Response<string>> RegisterAsync(RegisterRequest request, string origin)
        {
            var userWithSameUserName = await _userManager.FindByNameAsync(request.UserName);
            if (userWithSameUserName != null)
            {
                throw new ApiException($"Username '{request.UserName}' is already taken.");
            }
            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber,
                IsActive = request.ActivateUser,
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
            };

            if (!string.IsNullOrWhiteSpace(request.PhoneNumber))
            {
                var userWithSamePhoneNumber = await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == request.PhoneNumber);
                if (userWithSamePhoneNumber != null)
                {
                    throw new ApiException("Phone number { 0 } is already registered.", request.PhoneNumber);
                }
            }

            var userWithSameEmail = await _userManager.FindByEmailAsync(request.Email);
            if (userWithSameEmail == null)
            {
                var result = await _userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Roles.Basic.ToString());
                    //await _userManager.AddToRoleAsync(user, Roles.HR.ToString());
                    //var verificationUri = await SendVerificationEmail(user, origin);
                    //TODO: Attach Email Service here and configure it via appsettings
                    //await _emailService.SendAsync(new Application.DTOs.Email.EmailRequest() { From = "mail@codewithmukesh.com", To = user.Email, Body = $"Please confirm your account by visiting this URL {verificationUri}", Subject = "Confirm Registration" });
                    return new Response<string>(user.Id, message: $"User Registered Was Sucessfully");
                }
                else
                {
                    throw new ApiException($"{result.Errors}");
                }
            }
            else
            {
                throw new ApiException($"Email {request.Email } is already registered.");
            }
        }

        public async Task<Response<List<AccountResponse>>> GetAllAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var result = _mapper.Map<List<AccountResponse>>(users);
            return new Response<List<AccountResponse>>(result, "User accounts have successfully been retrieved.");
        }

        public async Task<Response<AccountResponse>> GetAsync(string userId)
        {
            var user = await _userManager.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();
            var result = _mapper.Map<AccountResponse>(user);
            return new Response<AccountResponse>(result, "User account have successfully been retrieved.");
        }

        public async Task<Response<string>> ToggleUserStatusAsync(ToggleUserStatusRequest request)
        {
            var user = await _userManager.Users.Where(u => u.Id == request.UserId).FirstOrDefaultAsync();
            var isAdmin = await _userManager.IsInRoleAsync(user, Roles.SuperAdmin.ToString());
            if (isAdmin)
            {
                throw new ApiException("Administrators Profile's Status cannot be toggled");
            }
            if (user != null)
            {
                user.IsActive = request.ActivateUser;
                var identityResult = await _userManager.UpdateAsync(user);
            }
            return new Response<string>("Successfully toggled user status");
        }




        //public async Task ForgotPassword(ForgotPasswordRequest model, string origin)
        //{
        //    var account = await _userManager.FindByEmailAsync(model.Email);

        //    // always return ok response to prevent email enumeration
        //    if (account == null) return;

        //    var code = await _userManager.GeneratePasswordResetTokenAsync(account);
        //    var route = "api/account/reset-password/";
        //    var _enpointUri = new Uri(string.Concat($"{origin}/", route));
        //    //var emailRequest = new EmailRequest()
        //    //{
        //    //    Body = $"You reset token is - {code}",
        //    //    To = model.Email,
        //    //    Subject = "Reset Password",
        //    //};
        //    //await _emailService.SendAsync(emailRequest);
        //}

        //public async Task<Response<string>> ResetPassword(ResetPasswordRequest model)
        //{
        //    var account = await _userManager.FindByEmailAsync(model.Email);
        //    if (account == null) throw new ApiException($"No Accounts Registered with {model.Email}.");
        //    var result = await _userManager.ResetPasswordAsync(account, model.Token, model.Password);
        //    if (result.Succeeded)
        //    {
        //        return new Response<string>(model.Email, message: $"Password Resetted.");
        //    }
        //    else
        //    {
        //        throw new ApiException($"Error occured while reseting the password.");
        //    }
        //}



        public async Task<int> GetCountAsync()
        {
            var count = await _userManager.Users.CountAsync();
            return count;
        }

        //public async Task<Response<List<AccountResponse>>> Fetch()
        //{
        //    //var response = new AccountResponse();
        //    //var user = await _userManager.Users.ToListAsync();
        //    //var account = _mapper.Map<List<AccountResponse>>(user);
        //    ////foreach (var item in user)
        //    ////{
        //    ////    var rolesList = await _userManager.GetRolesAsync(item).ConfigureAwait(false);
        //    ////    response.Roles = rolesList.ToList();
        //    ////}

        //    var users = await _userManager.Users.ToListAsync();
        //    var result = _mapper.Map<List<AccountResponse>>(users);
        //    return new Response<List<AccountResponse>>(result, "User accounts have successfully been retrieved.");
        //}

        //public async Task<Response<AccountResponse>> UserInfor(string email)
        //{
        //    var user = await _userManager.FindByEmailAsync(email);
        //    var account = _mapper.Map<AccountResponse>(user);
        //    return new Response<AccountResponse>(account, $"Authenticated {account.UserName}");
        //}
    }
}
