using CrazyPetals.Entities.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrazyPetals.Abstraction.Repositories
{
    public interface IFilterRepository : IRepository<Filter>
    {
        Task<List<Filter>> GetFilterAsync(int CategoryId, string AppId);
    }
}
