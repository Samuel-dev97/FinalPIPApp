//using Blazored.LocalStorage;
//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Components.Authorization;
//using Client.AuthProviders;

//using Client.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Threading.Tasks;
//using Client.Models;
//using Shared.Wrappers;

//namespace Client.Services
//{
//    public class AccountRepositoryAsync : IAccountRepositoryAsync
//    {
//        private readonly HttpClient _client;
//        private IHttpService _httpService;
//        //private ILocalStorageService _localStorageService;
//        private NavigationManager _navigationManager;

//        private readonly AuthenticationStateProvider _authStateProvider;
//        private readonly ILocalStorageService _localStorage;

//        public User User { get; private set; }

//        public AccountRepositoryAsync(
//            HttpClient client,
//            IHttpService httpService,
//            NavigationManager navigationManager,
//            AuthenticationStateProvider authStateProvider,
//            ILocalStorageService localStorage
//        )
//        {
//            _client = client;
//            _httpService = httpService;
//            _navigationManager = navigationManager;
//            _authStateProvider = authStateProvider;
//            _localStorage = localStorage;
//        }

//        public async Task<Response<AuthenticationResponse>> AuthenticateAsync(Authentication request)
//        {
//            var response = await _httpService.Post<Response<AuthenticationResponse>>($"identity/token", new { email = request.Email, password = request.Password });
//            if (response.Succeeded)
//            {
//                var token = response.Data.Token;
//                var refreshToken = response.Data.RefreshToken;
//                await _localStorage.SetItemAsync("authToken", token);
//                await _localStorage.SetItemAsync("refreshToken", refreshToken);

//                await ((AuthStateProvider)_authStateProvider).NotifyUserAuthentication();
//                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

//                return response;
//            }
//            else
//            {
//                return null;
//            }
//        }

//        public async Task Initialize()
//        {
//            User = await _localStorage.GetItemAsync<User>("user");
//        }

//        public async Task Logout()
//        {
//            await _localStorage.RemoveItemAsync("authToken");
//            await _localStorage.RemoveItemAsync("refreshToken");
//            ((AuthStateProvider)_authStateProvider).NotifyUserLogout();
//            _client.DefaultRequestHeaders.Authorization = null;
//            _navigationManager.NavigateTo("/");
//        }

//        public async Task<Response<string>> RegisterAsync(RegisterRequest request)
//        {
//            return await _httpService.Post<Response<string>>($"identity/user", request);
//        }

//        public async Task<Response<string>> ResetPassword(ResetPasswordRequest model)
//        {
//            return await _httpService.Post<Response<string>>($"Account/reset-password", model);
//        }

//        public async Task<Response<AccountResponse>> GetByIdAsync(string Id)
//        {
//            return await _httpService.Get<Response<AccountResponse>>($"identity/user/{Id}");
//        }

//        public async Task<Response<List<AccountResponse>>> GetAllAsync()
//        {
//            return await _httpService.Get<Response<List<AccountResponse>>>("identity/user");
//        }
//    }
//}
