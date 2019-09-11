using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyPetals.Entities.Resources
{
    public class BaseRequest
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string AppId { get; set; }
    }
    public class LoginRequest : BaseRequest
    {
        public string EmailId { get; set; }
        public string Password { get; set; }
    }
    public class ExternalLoginRequest : BaseRequest
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
    }
    public class VerifyOtpRequest : BaseRequest
    {
        public string OTP { get; set; }
    }
    public class ResetPasswordRequest : BaseRequest
    {
        public string Password { get; set; }
    }
    public class Register : ExternalLoginRequest
    {

        public string Password { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string AppId { get; set; }
        public IFormFile file { get; set; }
    }
    public class RegisterApiResponseResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
    public class RegisterResponse
    {
        public bool error { get; set; } = false;
        public string Message { get; set; }
        public RegisterApiResponseResource data { get; set; }
    }

    public class CommonResponse
    {
        public bool error { get; set; } = false;
        public string Message { get; set; }
    }
    public class MyProfile
    {
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public string ProfilePicture { get; set; }
    }
    public class MyProfileResponse
    {
        public bool error { get; set; } = false;
        public string Message { get; set; }
        public MyProfile data { get; set; }
    }

    
}
