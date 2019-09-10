using CrazyPetals.Entities.Filters;
using CrazyPetals.Entities.WebViewModels;
using System.Threading.Tasks;

namespace CrazyPetals.Abstraction.Service
{
    public interface IProductService
    {
        Task<int> AddProductAsync(AddProductViewModel model);
        Task<ProductWrapperViewModel> GetWrapperForIndexView(ProductFilter filter);
    }
}