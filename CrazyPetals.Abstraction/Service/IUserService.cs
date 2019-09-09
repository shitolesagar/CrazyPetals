using CrazyPetals.Entities.Database;
using CrazyPetals.Entities.Resources;
using System.Threading.Tasks;

namespace CrazyPetals.Abstraction.Service
{
    public interface IUserService
    {
        RegisterResponse RegisterUser(Register request);

        CommonResponse LoginUser(LoginRequest request);

        CommonResponse OTPSend(BaseRequest request);

        

        CommonResponse ResetPassword(ResetPasswordRequest request);
    }
}