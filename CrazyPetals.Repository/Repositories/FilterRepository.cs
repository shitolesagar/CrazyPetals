using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Entities.Database;
using CrazyPetals.Entities.Filters;
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

        public Task<List<Filter>> GetIndexViewRecordsAsync(FilterFilter filter, int skip, int pageSize)
        {
            return Set.Include(x => x.Category).Skip(skip).Take(pageSize).ToListAsync();
        }

        public int GetIndexViewTotalCount(FilterFilter filter)
        {
            return Set.Count();
        }
    }
}
