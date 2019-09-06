using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Entities.Database;

namespace CrazyPetals.Repository.Repositories
{
    public class AppThemeRepository : Repository<AppTheme>, IAppThemeRepository
    {
        public AppThemeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
