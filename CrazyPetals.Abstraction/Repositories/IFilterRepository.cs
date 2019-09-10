using CrazyPetals.Entities.Database;
using CrazyPetals.Entities.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrazyPetals.Abstraction.Repositories
{
    public interface IFilterRepository : IRepository<Filter>
    {
        Task<List<Filter>> GetFilterAsync(int CategoryId, string AppId);
        int GetIndexViewTotalCount(SubcategoryFilter filter);
        Task<List<Filter>> GetIndexViewRecordsAsync(SubcategoryFilter filter, int skip, int pageSize);
    }
}
