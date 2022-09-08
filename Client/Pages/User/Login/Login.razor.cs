using AntDesign;
using Client.Models;
using Client.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Shared.Models.Account;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Client.Pages.User
{
    public partial class Login
    {
        private AuthenticationRequest _model { get; set; } = new AuthenticationRequest();

        private bool loading;
        private string error;

        [Inject] public NavigationManager NavigationManager { get; set; }

        [Inject] public IAccountService AccountService { get; set; }

        [Inject] public MessageService Message { get; set; }

        protected async override Task OnInitializedAsync()
        {
            var state = await _authProvider.GetAuthenticationStateAsync();
            if (state == new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())))
            {
                _navigationManager.NavigateTo("/dashboard");
            }
        }

        public async Task HandleSubmit()
        {
            loading = true;
            try
            {
                var response = await _authenticationRepositoryAsync.Login(_model);
                if (response.Succeeded)
                {
                    NavigationManager.NavigateTo("/dashboard");
                    loading = false;
                    await MessageDisplay(_model.Email);
                }
                else
                {
                    error = response.Message;
                }
                // if (!response)
                //{
                //   error = 
                //var token = response.Data.JWToken;
                //var refreshToken = response.Data.RefreshToken;
                //await _localStorage.SetItemAsync("authToken", token);
                //await _localStorage.SetItemAsync("refreshToken", refreshToken);

                //await ((AuthStateProvider)_authStateProvider).NotifyUserAuthentication();
                //_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                //}
                //var returnUrl = NavigationManager.QueryString("returnUrl") ?? "";
                // loading = false;
                //NavigationManager.NavigateTo(returnUrl);
                //NavigationManager.NavigateTo("/");
            }
            catch (Exception ex)
            {
                error = ex.Message;
                loading = false;
                StateHasChanged();
            }
        }

        //public async Task GetCaptcha()
        //{
        //    var captcha = await AccountService.GetCaptchaAsync(_model.Mobile);
        //    await Message.Success($"Verification code validated successfully! The verification code is: {captcha}");
        //}
        private async Task MessageDisplay(string email)
        {
            await Message.Loading("Authenticating user..", 2.5)
              .ContinueWith((result) =>
              {
                  Message.Info($"Welcome! {email}", 2.5);
              });
        }
    }
}