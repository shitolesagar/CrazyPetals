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

        public Task<List<ApplicationUser>> GetCusotmerIndexViewRecordsAsync(FilterBase filter, int skip, int pageSize)
        {
            var query = Set.Where(x=> x.Role.Name == "Customer").AsQueryable();
            if(!string.IsNullOrEmpty(filter.search))
            {
                query = query.Where(x => x.Email.ToLower().Contains(filter.search.ToLower()) || x.Name.ToLower().Contains(filter.search.ToLower()));
            }
            return query.OrderByDescending(x => x.CreatedDate).Skip(skip).Take(pageSize).ToListAsync();
        }

        public int GetCustomerIndexViewTotalCount(FilterBase filter)
        {
            var query = Set.Where(x => x.Role.Name == "Customer").AsQueryable();
            if (!string.IsNullOrEmpty(filter.search))
            {
                query = query.Where(x => x.Email.ToLower().Contains(filter.search.ToLower()) || x.Name.ToLower().Contains(filter.search.ToLower()));
            }
            return query.Count();
        }
    }
}
