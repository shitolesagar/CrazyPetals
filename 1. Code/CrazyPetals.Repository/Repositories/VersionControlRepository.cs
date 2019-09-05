using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Entities.Database;

namespace CrazyPetals.Repository.Repositories
{
    public class VersionControlRepository : Repository<VersionControl>, IVersionControlRepository
    {
        public VersionControlRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
