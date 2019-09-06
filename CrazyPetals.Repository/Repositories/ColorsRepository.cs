using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Entities.Database;

namespace CrazyPetals.Repository.Repositories
{
    public class ColorsRepository : Repository<Colors>, IColorsRepository
    {
        public ColorsRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
