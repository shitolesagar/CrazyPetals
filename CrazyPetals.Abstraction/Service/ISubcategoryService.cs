using CrazyPetals.Entities.Filters;
using CrazyPetals.Entities.WebViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrazyPetals.Abstraction.Service
{
    public interface IFilterService
    {
        Task<int> AddFilterAsync(AddFilterViewModel model);
        Task<FilterWrapperViewModel> GetWrapperForIndexView(FilterForFilterModule filter);
        Task<List<IdNameViewModel>> GetCategoryList();
        Task<int> Deletefilter(int id);
        Task<AddFilterViewModel> getForEditAsync(int id);
        Task EditFilterAsync(int id, AddFilterViewModel model);
    }
}