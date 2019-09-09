using CrazyPetals.Entities.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrazyPetals.Abstraction.Repositories
{
    public interface IBannerRepository : IRepository<Banner>
    {
        Task<List<Banner>> GetBannerList(int skip, int take, string AppId);
    }
}
