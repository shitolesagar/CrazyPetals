using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Entities.Database;

namespace CrazyPetals.Repository.Repositories
{
    public class BannerRepository : Repository<Banner>, IBannerRepository
    {
        public BannerRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
