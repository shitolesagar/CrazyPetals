using CrazyPetals.Entities.Database;
using CrazyPetals.Entities.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrazyPetals.Abstraction.Repositories
{
    public interface ISubcategoryRepository : IRepository<Subcategory>
    {
        Task<List<Subcategory>> GetSubcategoryAsync(int CategoryId, string AppId);
        int GetIndexViewTotalCount(SubcategoryFilter filter);
        Task<List<Subcategory>> GetIndexViewRecordsAsync(SubcategoryFilter filter, int skip, int pageSize);
    }
}
