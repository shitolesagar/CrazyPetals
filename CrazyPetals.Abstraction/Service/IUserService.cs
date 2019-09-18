using CrazyPetals.Entities.Database;
using CrazyPetals.Entities.Filters;
using CrazyPetals.Entities.Resources;
using CrazyPetals.Entities.WebViewModels;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CrazyPetals.Abstraction.Service
{
    public interface IUserService
    {
        RegisterResponse RegisterUserWithData(RegisterWithData request);

        Task<RegisterWithImageResponse> RegisterUserWithImage(RegisterWithImage request);

        CommonResponse LoginUser(LoginRequest request);

        CommonResponse OTPSend(BaseRequest request);

        CommonResponse ResetPassword(ResetPasswordRequest request);

        Task<CustomerWrapperViewModel> GetWrapperForIndexView(FilterBase filter);

        CommonResponse VerifyOTP(VerifyOtpRequest request);

        MyProfileResponse GetMyProfile(int Id);
        Task<CustomerDetailsViewModel> GetCustomerDetails(int id);
    }
}