using CrazyPetals.Entities.Database;
using CrazyPetals.Entities.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrazyPetals.Abstraction.Repositories
{
    public interface INotificationRepository : IRepository<Notification>
    {
        Task<List<Notification>> GetNotificationList(int skip, int take, string AppId);
        int GetIndexViewTotalCount(FilterBase filter);
        Task<List<Notification>> GetIndexViewRecordsAsync(FilterBase filter, int skip, int pageSize);
    }
}
