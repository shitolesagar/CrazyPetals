using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Entities.Database;
using CrazyPetals.Entities.Resources;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrazyPetals.Repository.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<List<Product>> GetProductList(ProductListRequestResource request)
        {
            return Set.Where(x => x.AppId == request.AppId && x.CategoryId == request.CategoryId).Skip(0).Take(request.take).ToListAsync();
        }

        public Task<List<Product>> GetProductListForSearch(int take, string AppId, string Search)
        {
            return Set.Include(x=>x.Category).Include(x=>x.ProductImages).Include(x=>x.FilterProducts).ThenInclude(y=>y.Filter). Where(x => x.AppId == AppId && x.Name.Contains(Search)).Skip(0).Take(take).ToListAsync();
        }

        public Product FindById(int Id, string AppId)
        {
            return Set.Include(x => x.ProductImages).Include(x=>x.ProductColors).ThenInclude(y=>y.Colors).Include(x=>x.ProductSizes).ThenInclude(y=>y.Size). Where(x => x.AppId == AppId &&  x.Id == Id).FirstOrDefault();
        }

        public Task<Product> GetProductDetailAsync(int id, string AppId)
        {
            return Set.Where(x => x.AppId == AppId).Include(x => x.ProductImages).Include(x => x.ProductColors).ThenInclude(y => y.Colors).Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
