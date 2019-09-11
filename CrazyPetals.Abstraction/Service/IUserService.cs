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
        Task<RegisterResponse> RegisterUser(Register request);

        CommonResponse LoginUser(LoginRequest request);

        CommonResponse OTPSend(BaseRequest request);

        CommonResponse ResetPassword(ResetPasswordRequest request);

        Task<UserWrapperViewModel> GetWrapperForIndexView(UserFilter filter);

        CommonResponse VerifyOTP(VerifyOtpRequest request);

        MyProfileResponse GetMyProfile(int Id);
    }
}