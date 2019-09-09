using CrazyPetals.Entities.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrazyPetals.Abstraction.Repositories
{
    public interface INotificationRepository : IRepository<Notification>
    {
        Task<List<Notification>> GetNotificationList(int skip, int take, string AppId);
    }
}
