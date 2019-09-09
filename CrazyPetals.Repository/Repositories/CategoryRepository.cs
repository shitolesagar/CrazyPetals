using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Entities.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrazyPetals.Repository.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {

        }

        public Task<List<Category>> GetCategoryList(int skip, int take, string AppId)
        {
            return Set.Where(x => x.AppId == AppId).Skip(skip).Take(take).ToListAsync();
        }
    }
}
