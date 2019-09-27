using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Entities.Database;
using CrazyPetals.Entities.Filters;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrazyPetals.Repository.Repositories
{
    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        public NotificationRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<List<Notification>> GetIndexViewRecordsAsync(FilterBase filter, int skip, int pageSize)
        {
            return Set.OrderByDescending(x => x.CreatedDate).Skip(skip).Take(pageSize).ToListAsync();
        }

        public int GetIndexViewTotalCount(FilterBase filter)
        {
            return Set.Count();
        }

        public Task<List<Notification>> GetNotificationList(int skip, int take, string AppId)
        {
            return Set.Where(x => x.AppId == AppId).Skip(skip).Take(take).ToListAsync();
        }
    }
}
