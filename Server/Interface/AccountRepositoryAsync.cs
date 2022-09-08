using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Server.Ctx.Models.Identity;
using Server.Exceptions;
using Shared.Wrappers;
using Shared.Models.Identity;

namespace Server.Interface
{
    public interface IAccountRepositoryAsync
    {
        Task<Response<string>> ChangePasswordAsync(ChangePasswordRequest model, string userId);
        Task<Response<string>> UpdateProfileAsync(UpdateProfileRequest request, string userId);
    }
    public class AccountRepositoryAsync : IAccountRepositoryAsync
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountRepositoryAsync(UserManager<ApplicationUser> userManager,
          SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<Response<string>> ChangePasswordAsync(ChangePasswordRequest model, string userId)
        {
            var user = await this._userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new ApiException("User Not Found.");
            }

            var identityResult = await this._userManager.ChangePasswordAsync(
                user,
                model.Password,
                model.NewPassword);
            var errors = identityResult.Errors.Select(e => e.Description.ToString()).ToList();
            return identityResult.Succeeded ? new Response<string>("Password Updated Succesfully") : new Response<string>($"{ errors }");
        }

        public async Task<Response<string>> UpdateProfileAsync(UpdateProfileRequest request, string userId)
        {
            if (!string.IsNullOrWhiteSpace(request.PhoneNumber))
            {
                var userWithSamePhoneNumber = await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == request.PhoneNumber);
                if (userWithSamePhoneNumber != null)
                {
                    throw new ApiException(string.Format("Phone number {0} is already used.", request.PhoneNumber));
                }
            }

            var userWithSameEmail = await _userManager.FindByEmailAsync(request.Email);
            if (userWithSameEmail == null || userWithSameEmail.Id == userId)
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    throw new ApiException("User Not Found.");
                }
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.PhoneNumber = request.PhoneNumber;
                var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
                if (request.PhoneNumber != phoneNumber)
                {
                    var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, request.PhoneNumber);
                }
                var identityResult = await _userManager.UpdateAsync(user);
                var errors = identityResult.Errors.Select(e => e.Description.ToString()).ToList();
                await _signInManager.RefreshSignInAsync(user);
                return identityResult.Succeeded ? new Response<string>("User Profile Have Been Updated Succesfully") : new Response<string>($"{ errors }");
            }
            else
            {
                throw new ApiException(string.Format("Email {0} is already used.", request.Email));
            }
        }
    }
}
