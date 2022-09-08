
//using Client.Models;
//using Shared.Wrappers;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;
//using System.Threading.Tasks;

//namespace Client.Interfaces
//{
//    public interface IAuthenticationRepositoryAsync
//    {
//        Task<Response<AuthenticationResponse>> Login(AuthenticationRequest model);

//        Task<bool> Logout();

//        Task<string> RefreshToken();

//        Task<string> TryRefreshToken();

//        Task<string> TryForceRefreshToken();

//        Task<ClaimsPrincipal> CurrentUser();
//    }
//}
