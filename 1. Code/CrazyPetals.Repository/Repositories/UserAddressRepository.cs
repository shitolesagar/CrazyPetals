using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Entities.Database;

namespace CrazyPetals.Repository.Repositories
{
    public class UserAddressRepository : Repository<UserAddress>, IUserAddressRepository
    {
        public UserAddressRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
