using CrazyPetals.Entities.Database;

namespace CrazyPetals.Abstraction.Repositories
{
    public interface IForgotPasswordRepository : IRepository<ForgotPassword>
    {
        ForgotPassword FindByEmailOtp(string Email, string OTP);
    }
}
