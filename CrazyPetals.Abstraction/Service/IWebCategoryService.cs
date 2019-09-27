using CrazyPetals.Entities.Filters;
using CrazyPetals.Entities.WebViewModels;
using System.Threading.Tasks;

namespace CrazyPetals.Abstraction.Service
{
    public interface IWebCategoryService
    {
        Task<int> AddCategoryAsync(AddCategoryViewModel model, string imageRelativePath);
        Task<int> EditCategoryAsync(int id, AddCategoryViewModel model, string imageRelativePath);
        Task<CategoryWrapperViewModel> GetWrapperForIndexView(FilterBase filter);
        Task<int> DeleteCategory(int id);
        Task<AddCategoryViewModel> getForEditAsync(int id);
    }
}