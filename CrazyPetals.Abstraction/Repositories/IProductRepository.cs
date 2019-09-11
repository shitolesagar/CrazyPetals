using CrazyPetals.Entities.Database;
using CrazyPetals.Entities.Filters;
using CrazyPetals.Entities.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrazyPetals.Abstraction.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> GetProductList(ProductListRequestResource request);

        Task<List<Product>> GetProductListForSearch(int take, string AppId, string search);

        Product FindById(int Id, string AppId);

        Task<Product> GetProductDetailAsync(int id, string AppId);
        int GetIndexViewTotalCount(ProductFilter filter);
        Task<List<Product>> GetIndexViewRecordsAsync(ProductFilter filter, int skip, int pageSize);

        List<Product> GetAllProductForCategory(int CategoryId, string AppId, int skip, int take);

        List<Product> GetAllProductForRecommended(int CategoryId,int ProductId, string AppId, int skip, int take);

        List<Product> GetAllProductForCategory(int CategoryId, string AppId);

        List<Product> GetAllProductForRecommended(int CategoryId,int ProductId, string AppId);
    }
}
