using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyPetals.Entities.Resources
{
    public class BaseRequest
    {
        public string PhoneNumber { get; set; }
        public string AppId { get; set; }
    }
    public class LoginRequest : BaseRequest
    {
        public string Password { get; set; }
    }
    public class ExternalLoginRequest : BaseRequest
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
    }
    public class VerifyOtpRequest : BaseRequest
    {
        public string Otp { get; set; }
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
    }
    public class RegisterApiResponseResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
