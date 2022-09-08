using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Client.DTOs
{
    public class AuthenticationRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class Authentication
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class AuthenticationResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }

    public class User
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public bool IsVerified { get; set; }
        public string JWToken { get; set; }
        [JsonIgnore]
        public string RefreshToken { get; set; }
        public DateTime TokenExpireTime { get; set; }
    }

    public class RegisterRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        //  [EmailAddress]
        public string Email { get; set; }
        public string UserName { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public bool ActivateUser { get; set; } = false;
        //  [Required]
        public IEnumerable<string> Roles { get; set; }
    }

    //public class AccountResponse
    //{
    //    public string Id { get; set; }
    //    [DisplayName("USERNAME")]
    //    public string UserName { get; set; }
    //    [DisplayName("EMAIL")]
    //    public string Email { get; set; }
    //    [DisplayName("FullName")]
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public List<string> Roles { get; set; }
    //}

    public class AccountResponse
    {
        [DisplayName("ID")]
        public string Id { get; set; }
        [DisplayName("USERNAME")]
        public string UserName { get; set; }
        [DisplayName("FULLNAME")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DisplayName("EMAIL")]
        public string Email { get; set; }
        public bool IsActive { get; set; } = true;
        public bool EmailConfirmed { get; set; }
        [DisplayName("PHONENUMBER")]
        public string PhoneNumber { get; set; }
    }

    public class ResetPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Token { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }

    public class RefreshTokenRequest
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}

