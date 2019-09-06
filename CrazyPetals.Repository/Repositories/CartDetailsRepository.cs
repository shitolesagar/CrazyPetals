using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Entities.Database;

namespace CrazyPetals.Repository.Repositories
{
    public class CartDetailsRepository : Repository<CartDetails>, ICartDetailsRepository
    {
        public CartDetailsRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
