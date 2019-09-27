using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Entities.Database;

namespace CrazyPetals.Repository.Repositories
{
    public class FilterProductRepository : Repository<FilterProduct>, IFilterProductRepository
    {
        public FilterProductRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
