using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Entities.Database;

namespace CrazyPetals.Repository.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
