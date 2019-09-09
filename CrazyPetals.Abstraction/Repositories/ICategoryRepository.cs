using CrazyPetals.Entities.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrazyPetals.Abstraction.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<List<Category>> GetCategoryList(int skip, int take, string AppId);
    }
}
