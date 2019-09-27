using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Entities.Database;
using Microsoft.EntityFrameworkCore;

namespace CrazyPetals.Repository.Repositories
{
    public class ProductColorRepository : Repository<ProductColor>, IProductColorRepository
    {
        public ProductColorRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<List<ProductColor>> GetAllAsync(int productId)
        {
            return Set.Where(x => x.ProductId == productId).ToListAsync();
        }
    }
}
