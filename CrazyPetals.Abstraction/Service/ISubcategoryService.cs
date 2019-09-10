using CrazyPetals.Entities.Filters;
using CrazyPetals.Entities.WebViewModels;
using System.Threading.Tasks;

namespace CrazyPetals.Abstraction.Service
{
    public interface ISubcategoryService
    {
        Task<int> AddSubcategoryAsync(AddSubcategoryViewModel model);
        Task<SubcategoryWrapperViewModel> GetWrapperForIndexView(SubcategoryFilter filter);
    }
}