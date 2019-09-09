using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Entities.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrazyPetals.Repository.Repositories
{
    public class FilterRepository : Repository<Filter>, IFilterRepository
    {
        public FilterRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<List<Filter>> GetFilterAsync(int CategoryId, string AppId)
        {
            return Set.Where(x => x.AppId == AppId && x.CategoryId == CategoryId).ToListAsync();
        }
    }
}
