using CrazyPetals.Entities.Database;
using CrazyPetals.Entities.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrazyPetals.Abstraction.Repositories
{
    public interface IFilterRepository : IRepository<Filter>
    {
        Task<List<Filter>> GetFilterAsync(int CategoryId, string AppId);
        int GetIndexViewTotalCount(FilterForFilterModule filter);
        Task<List<Filter>> GetIndexViewRecordsAsync(FilterForFilterModule filter, int skip, int pageSize);
    }
}
