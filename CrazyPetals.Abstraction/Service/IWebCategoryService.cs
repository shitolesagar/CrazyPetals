using CrazyPetals.Entities.Filters;
using CrazyPetals.Entities.WebViewModels;
using System.Threading.Tasks;

namespace CrazyPetals.Abstraction.Service
{
    public interface IWebCategoryService
    {
        Task<int> AddCategoryAsync(AddCategoryViewModel model, string imageRelativePath);
        Task<CategoryWrapperViewModel> GetWrapperForIndexView(FilterBase filter);
    }
}