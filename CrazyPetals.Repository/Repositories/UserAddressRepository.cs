using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Entities.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrazyPetals.Repository.Repositories
{
    public class UserAddressRepository : Repository<UserAddress>, IUserAddressRepository
    {
        public UserAddressRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<List<UserAddress>> GetAllAddressForUser(string AppId, int ApplicationUserId)
        {
            return Set.Where(x => x.ApplicationUserId == ApplicationUserId && x.AppId == AppId && x.IsDeleted==false).ToListAsync();
        }
    }
}
