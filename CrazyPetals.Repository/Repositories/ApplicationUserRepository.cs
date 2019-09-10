using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Entities.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CrazyPetals.Repository.Repositories
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ApplicationUser FindByEmail(string Email)
        {

            return Set.Where(x => x.Email == Email).FirstOrDefault();
        }
    }
}
