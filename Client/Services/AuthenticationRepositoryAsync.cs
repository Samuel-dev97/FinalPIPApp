//using Blazored.LocalStorage;
//using Microsoft.AspNetCore.Components.Authorization;
//using Client.AuthProviders;
//using Client.;
//using Client.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Net.Http.Json;
//using System.Security.Claims;
//using System.Threading.Tasks;

//namespace Client.Services
//{
//    public class AuthenticationRepositoryAsync : IAuthenticationRepositoryAsync
//    {
//        private readonly HttpClient _httpClient;
//        private readonly ILocalStorageService _localStorage;
//        private readonly AuthenticationStateProvider _authenticationStateProvider;
//        public AuthenticationRepositoryAsync(HttpClient httpClient,
//            ILocalStorageService localStorage,
//            AuthenticationStateProvider authenticationStateProvider)
//        {
//            _httpClient = httpClient;
//            _localStorage = localStorage;
//            _authenticationStateProvider = authenticationStateProvider;
//        }
//        public async Task<ClaimsPrincipal> CurrentUser()
//        {
//            var state = await _authenticationStateProvider.GetAuthenticationStateAsync();
//            return state.User;
//        }

//        public async Task<Response<AuthenticationResponse>> Login(AuthenticationRequest model)
//        {
//            var response = await _httpClient.PostAsJsonAsync("identity/token", model);
//            var result = await response.Content.ReadFromJsonAsync<Response<AuthenticationResponse>>();
//            if (result.Succeeded)
//            {
//                var token = result.Data.Token;
//                var refreshToken = result.Data.RefreshToken;
//                await _localStorage.SetItemAsync("authToken", token);
//                await _localStorage.SetItemAsync("refreshToken", refreshToken);

//                await ((AuthStateProvider)this._authenticationStateProvider).NotifyUserAuthentication();

//                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

//                return result;
//            }
//            else
//            {
//                return null;
//            }
//        }

//        public async Task<bool> Logout()
//        {
//            await _localStorage.RemoveItemAsync("authToken");
//            await _localStorage.RemoveItemAsync("refreshToken");
//            ((AuthStateProvider)_authenticationStateProvider).NotifyUserLogout();
//            _httpClient.DefaultRequestHeaders.Authorization = null;
//            return true;
//        }

//        public async Task<string> RefreshToken()
//        {
//            var token = await _localStorage.GetItemAsync<string>("authToken");
//            var refreshToken = await _localStorage.GetItemAsync<string>("refreshToken");

//            var response = await _httpClient.PostAsJsonAsync("identity/token/refresh", new RefreshTokenRequest { Token = token, RefreshToken = refreshToken });

//            var result = await response.Content.ReadFromJsonAsync<Response<AuthenticationResponse>>();

//            if (!result.Succeeded)
//            {
//                throw new ApplicationException("Something went wrong during the refresh token action");
//            }

//            token = result.Data.Token;
//            refreshToken = result.Data.RefreshToken;
//            await _localStorage.SetItemAsync("authToken", token);
//            await _localStorage.SetItemAsync("refreshToken", refreshToken);
//            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
//            return token;
//        }

//        public async Task<string> TryForceRefreshToken()
//        {
//            //check if token exists
//            var availableToken = await _localStorage.GetItemAsync<string>("refreshToken");
//            if (string.IsNullOrEmpty(availableToken)) return string.Empty;
//            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
//            var user = authState.User;
//            var exp = user.FindFirst(c => c.Type.Equals("exp"))?.Value;
//            var expTime = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(exp));
//            var timeUTC = DateTime.UtcNow;
//            var diff = expTime - timeUTC;
//            if (diff.TotalMinutes <= 1)
//                return await RefreshToken();
//            return string.Empty;
//        }

//        public async Task<string> TryRefreshToken()
//        {
//            return await RefreshToken();
//        }
//    }
//}
