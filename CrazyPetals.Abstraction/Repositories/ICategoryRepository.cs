using CrazyPetals.Entities.Database;
using CrazyPetals.Entities.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrazyPetals.Abstraction.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<List<Category>> GetCategoryList(int skip, int take, string AppId);
        int GetIndexViewTotalCount(FilterBase filter);
        Task<List<Category>> GetIndexViewRecordsAsync(FilterBase filter, int skip, int pageSize);
        Category FindCategoryWithoutProducts(int id);
    }
}
