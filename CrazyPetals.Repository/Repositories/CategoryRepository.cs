using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Entities.Database;
using CrazyPetals.Entities.Filters;
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

        public Category FindCategoryWithoutProducts(int id)
        {
            return Set.FirstOrDefault(x => x.Id == id && x.Products.Count <= 0);
        }

        public Task<List<Category>> GetCategoryList(int skip, int take, string AppId)
        {
            return Set.Where(x => x.AppId == AppId && x.Products.Count() > 0).Skip(skip).Take(take).ToListAsync();
        }

        public Task<List<Category>> GetIndexViewRecordsAsync(FilterBase filter, int skip, int pageSize)
        {
            return Set.Skip(skip).Take(pageSize).ToListAsync();
        }

        public int GetIndexViewTotalCount(FilterBase filter)
        {
            return Set.Count();
        }
    }
}
