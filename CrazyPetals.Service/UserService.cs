using CrazyPetals.Abstraction;
using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Abstraction.Service;
using CrazyPetals.Entities.Constant;
using CrazyPetals.Entities.Database;
using CrazyPetals.Entities.Filters;
using CrazyPetals.Entities.Resources;
using CrazyPetals.Entities.WebViewModels;
using CrazyPetals.Service.ExtensionMethods;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CrazyPetals.Service
{
    public class UserService : IUserService
    {
        private ICategoryRepository _categoryRepository;
        private IUnitOfWork _unitOfWork;
        private IEmailService _emailService;
        private IFileServices _fileServices;
        private IProductImagesRepository _productImagesRepository;
        private IUserAddressRepository _userAddressRepository;
        private IOrderRepository _orderSummaryRepository;
        private IOrderDetailsRepository _orderDetailsRepository;
        private IApplicationUserRepository _applicationUserRepository;
        private IForgotPasswordRepository _forgotPasswordRepository;


        public UserService(ICategoryRepository categoryRepository, IFileServices fileServices, IEmailService emailService, IForgotPasswordRepository forgotPasswordRepository, IApplicationUserRepository applicationUserRepository, IOrderDetailsRepository orderDetailsRepository, IOrderRepository orderSummaryRepository, IUserAddressRepository userAddressRepository, IProductImagesRepository productImagesRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
            _productImagesRepository = productImagesRepository;
            _userAddressRepository = userAddressRepository;
            _orderSummaryRepository = orderSummaryRepository;
            _orderDetailsRepository = orderDetailsRepository;
            _applicationUserRepository = applicationUserRepository;
            _forgotPasswordRepository = forgotPasswordRepository;
            _emailService = emailService;
            _fileServices = fileServices;
        }

        #region RegisterUser
        public async Task<RegisterResponse> RegisterUser(Register request)
        {

            RegisterResponse res = new RegisterResponse();

            var user = _applicationUserRepository.FindByEmail(request.EmailId);


            try
            {
                if (user != null)
                {
                    res.error = true;
                    res.Message = StringConstants.UserExist;
                    return res;
                }
                else
                {
                    string relativePath = await _fileServices.SaveImageAndReturnRelativePath(request.file, FolderConstants.UserFolder);
                    user = new ApplicationUser
                    {
                        Name = request.Name,
                        Email = request.EmailId,
                        AppId = request.AppId,
                        RoleId = 3,
                        MobileNumber = request.PhoneNumber,
                        ProfilePicture = relativePath,
                    };

                    if (!string.IsNullOrEmpty(request.Password))
                    {
                        CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

                        user.PasswordHash = passwordHash;
                        user.PasswordSalt = passwordSalt;
                        user.CreatedDate = DateTime.Now;
                    }
                    _applicationUserRepository.Add(user);
                    _unitOfWork.SaveChanges();
                    var obj = new RegisterApiResponseResource
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Email = user.Email,
                    };
                    res.data = obj;
                    res.Message = StringConstants.UserSaved;
                    return res;
                }
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                res.error = true;
                res.Message = StringConstants.ServerError;
                return res;
            }
        }
        #endregion


        #region Login
        public CommonResponse LoginUser(LoginRequest request)
        {
            CommonResponse res = new CommonResponse();
            var user = _applicationUserRepository.FindByEmail(request.EmailId);
            if (user != null && user.AppId == request.AppId)
            {
                if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                {
                    res.error = true;
                    res.Message = StringConstants.LoginError;
                    return res;
                }
                res.Message = StringConstants.LoginSuccess;
                return res;
            }
            res.error = true;
            res.Message = StringConstants.ServerError;
            return res;
        }
        #endregion

        #region SendOTP
        public CommonResponse OTPSend(BaseRequest request)
        {
            CommonResponse res = new CommonResponse();

            try
            {
                var user = _applicationUserRepository.FindByEmail(request.Email);
                if (user != null)
                {
                    if (user.RoleId != 3)
                    {
                        res.error = true;
                        res.Message = StringConstants.UserNotAuthorised;
                        return res;
                    }

                    string code = CreateOtp();
                    ForgotPassword record = new ForgotPassword()
                    {
                        ExpireDate = DateTime.Now.AddMinutes(30),
                        OTP = code,
                        ApplicationUserId = user.Id,
                    };
                    _forgotPasswordRepository.Add(record);
                    _unitOfWork.SaveChanges();
                    _emailService.SendEmail(user.Email, ForgotPasswordOtpMailBody(code), "Reset Password");
                    res.Message = StringConstants.OTPSent;
                    return res;
                }
                else
                {
                    res.error = true;
                    res.Message = StringConstants.NoUser;
                    return res;
                }
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                res.error = true;
                res.Message = StringConstants.ServerError;
                return res;
            }
        }

        #endregion

        #region VerifyOTP
        public CommonResponse VerifyOTP(VerifyOtpRequest request)
        {
            CommonResponse res = new CommonResponse();
            var userData = _forgotPasswordRepository.FindByEmailOtp(request.Email, request.OTP);
            if (userData != null)
            {
                res.Message = StringConstants.OTPMatch;
                return res;
            }
            res.error = true;
            res.Message = StringConstants.OTPNotMatch;
            return res;
        }
        #endregion


        #region ResetPassword
        public CommonResponse ResetPassword(ResetPasswordRequest request)
        {
            CommonResponse res = new CommonResponse();
            var user = _applicationUserRepository.FindByEmail(request.Email);
            if (user != null && user.AppId == request.AppId)
            {
                CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                _unitOfWork.SaveChanges();
                res.Message = StringConstants.PasswordReset;
                return res;
            }
            res.error = true;
            res.Message = StringConstants.ServerError;
            return res;
        }
        #endregion

        #region GetMyProfile
        public MyProfileResponse GetMyProfile(int Id)
        {
            MyProfileResponse res = new MyProfileResponse();
            try
            {
                var profile = _applicationUserRepository.FindById(Id);
                MyProfile obj = new MyProfile()
                {
                    Name = profile.Name,
                    MobileNumber = profile.MobileNumber,
                    EmailId = profile.Email,
                    ProfilePicture = StringConstants.CPImageUrl + profile.ProfilePicture
                };
                res.Message = StringConstants.Success;
                res.data = obj;
                return res;
            }
            catch (Exception e)
            {
                res.error = true;
                res.Message = StringConstants.ServerError;
                return res;
            }
        }
        #endregion

        #region Private Methods

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private Object CreateResponseAfterSuccessfulAuthantication(ApplicationUser user)
        {
            return new
            {
                Token = new JwtSecurityTokenHandler().WriteToken(CreateClaimsAndJwtToken(user)),
                UserId = user.Id,
                EmailId = user.Email,
                Name = user.Name
            };
        }
        private JwtSecurityToken CreateClaimsAndJwtToken(ApplicationUser user)
        {
            var claims = new[]
               {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is my secreate key please check"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            return new JwtSecurityToken(
                issuer: "yourdomain.com",
                audience: "yourdomain.com",
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private string ForgotPasswordMailBody(string code, string baseUrl)
        {
            baseUrl += "Account/ResetPassword?metadata=" + code;
            string msg = "<p>Hi User,</p>\r\n<p>&nbsp; &nbsp; &nbsp;To reset your password, please <a title=\"Reset password link\" href=\"" + baseUrl + "\" target=\"_blank\" rel=\"noopener\">click here</a>. This link is valid for 12 hours.</p>\r\n<p>Thanks &amp; Regards <br /> Plugable Team</p>";
            return msg;
        }

        private string ForgotPasswordOtpMailBody(string otp)
        {
            string msg = "<p>Hi User,</p>\r\n<p>&nbsp; &nbsp; &nbsp; To reset your password, OTP is " + otp + ". This OTP is valid for 30 min.</p>\r\n<p>Thanks &amp; Regards <br /> Crazy Petals</p>";
            return msg;
        }

        private string CreateGuid()
        {
            return Guid.NewGuid().ToString("N");
        }

        private string CreateOtp()
        {
            char[] charArr = "0123456789".ToCharArray();
            string strrandom = string.Empty;
            Random otp = new Random();
            for (int i = 0; i < 4; i++)
            {
                int pos = otp.Next(1, charArr.Length);
                strrandom += charArr.GetValue(pos);
            }
            return strrandom;
        }

        public async Task<CustomerWrapperViewModel> GetWrapperForIndexView(FilterBase filter)
        {
            CustomerWrapperViewModel ResponseModel = new CustomerWrapperViewModel
            {
                TotalCount = _applicationUserRepository.GetCustomerIndexViewTotalCount(filter)
            };
            ResponseModel.PagingData = new PagingData(ResponseModel.TotalCount, filter.PageSize, filter.PageIndex);
            List<ApplicationUser> list = await _applicationUserRepository.GetCusotmerIndexViewRecordsAsync(filter, (filter.PageIndex - 1) * filter.PageSize, filter.PageSize);
            ResponseModel.UserList = list.Select((x, index) => new CustomerListViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                CreatedDate = x.CreatedDate.ToCrazyPattelsPattern(),
                Number = ResponseModel.PagingData.FromRecord + index,
            }).ToList();
            ResponseModel.PagingData = new PagingData(ResponseModel.TotalCount, filter.PageSize, filter.PageIndex);
            return ResponseModel;
        }

        #endregion
    }
}
