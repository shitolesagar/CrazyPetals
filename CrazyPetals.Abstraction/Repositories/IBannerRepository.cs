using CrazyPetals.Entities.Database;
using CrazyPetals.Entities.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrazyPetals.Abstraction.Repositories
{
    public interface IBannerRepository : IRepository<Banner>
    {
        Task<List<Banner>> GetBannerList(int skip, int take, string AppId);
        int GetIndexViewTotalCount(BannerFilter filter);
        Task<List<Banner>> GetIndexViewRecordsAsync(BannerFilter filter, int skip, int pageSize);
    }
}
