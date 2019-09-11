using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Entities.Database;
using CrazyPetals.Entities.Filters;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public Task<List<ApplicationUser>> GetIndexViewRecordsAsync(UserFilter filter, int skip, int pageSize)
        {
            return Set.Include(x => x.Role).Skip(skip).Take(pageSize).ToListAsync();
        }

        public int GetIndexViewTotalCount(UserFilter filter)
        {
            return Set.Count();
        }
    }
}
