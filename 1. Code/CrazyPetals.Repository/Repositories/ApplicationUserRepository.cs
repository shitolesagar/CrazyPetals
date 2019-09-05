using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Entities.Database;
using System.Linq;

namespace CrazyPetals.Repository.Repositories
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ApplicationUser FindByEmail(string Email)
        {

            return Set.FirstOrDefault(x => x.Email == Email);
        }
    }
}
