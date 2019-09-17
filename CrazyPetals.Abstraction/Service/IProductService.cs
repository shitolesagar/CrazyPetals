using CrazyPetals.Entities.Filters;
using CrazyPetals.Entities.WebViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrazyPetals.Abstraction.Service
{
    public interface IProductService
    {
        Task<int> AddProductAsync(AddProductViewModel model, List<string> imageUrls);
        Task<ProductWrapperViewModel> GetWrapperForIndexView(ProductFilter filter);
        Task<List<IdNameViewModel>> GetCategoryListAsync();
        Task<List<IdNameViewModel>> GetFilterListAsync();
        Task<List<IdNameViewModel>> GetColorListAsync();
        Task<List<IdNameViewModel>> GetAvailableSizeList();
    }
}