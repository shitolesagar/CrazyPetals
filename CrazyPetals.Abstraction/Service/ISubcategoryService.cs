using CrazyPetals.Entities.Filters;
using CrazyPetals.Entities.WebViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrazyPetals.Abstraction.Service
{
    public interface IFilterService
    {
        Task<int> AddFilterAsync(AddFilterViewModel model);
        Task<FilterWrapperViewModel> GetWrapperForIndexView(FilterFilter filter);
        Task<List<IdNameViewModel>> GetCategoryList();
    }
}