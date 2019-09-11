using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Entities.Database;
using CrazyPetals.Entities.Filters;
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

        public int GetIndexViewTotalCount(ProductFilter filter)
        {
            return Set.Count();
        }

        public Task<List<Product>> GetIndexViewRecordsAsync(ProductFilter filter, int skip, int pageSize)
        {
            return Set.Include(x => x.Category).Skip(skip).Take(pageSize).ToListAsync();
        }
        public List<Product> GetAllProductForCategory(int CategoryId, string AppId, int skip, int take)
        {
            return Set.Where(x => x.AppId == AppId).Include(x => x.ProductImages).Where(x => x.CategoryId == CategoryId).Where(x => x.IsDeleted == false).OrderByDescending(x => x.Id).Skip(skip).Take(take).ToList();
        }

        public List<Product> GetAllProductForCategory(int CategoryId, string AppId)
        {
            return Set.Where(x => x.AppId == AppId).Include(x => x.ProductImages).Where(x => x.CategoryId == CategoryId).Where(x => x.IsDeleted == false).ToList();
        }
    }
}
