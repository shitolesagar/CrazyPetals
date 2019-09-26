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

        public Task<List<Filter>> GetIndexViewRecordsAsync(FilterForFilterModule filter, int skip, int pageSize)
        {
            var query = Set.AsQueryable();
            if (filter.CategoryId != 0)
                query = query.Where(x => x.CategoryId == filter.CategoryId);
            return query.Include(x => x.Category).OrderByDescending(x => x.Id).Skip(skip).Take(pageSize).ToListAsync();
        }

        public int GetIndexViewTotalCount(FilterForFilterModule filter)
        {
            var query = Set.AsQueryable();
            if (filter.CategoryId != 0)
                query = query.Where(x => x.CategoryId == filter.CategoryId);
            return query.Count();
        }
    }
}
