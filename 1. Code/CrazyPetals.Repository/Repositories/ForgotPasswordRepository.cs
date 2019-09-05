using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Entities.Database;

namespace CrazyPetals.Repository.Repositories
{
    public class ForgotPasswordRepository : Repository<ForgotPassword>, IForgotPasswordRepository
    {
        public ForgotPasswordRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
