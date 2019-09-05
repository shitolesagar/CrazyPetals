using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Entities.Database;

namespace CrazyPetals.Repository.Repositories
{
    public class ActivityLogRepository : Repository<ActivityLog>, IActivityLogRepository
    {
        public ActivityLogRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
