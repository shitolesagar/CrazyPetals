using System.Collections.Generic;
using System.Threading.Tasks;
using CrazyPetals.Entities.Database;
using CrazyPetals.Entities.Filters;
using CrazyPetals.Entities.WebViewModels;

namespace CrazyPetals.Abstraction.Service
{
    public interface IBannerService
    {
        Task<int> AddBannerAsync(AddBannerViewModel model, string imageRelativePath);
        Task<BannerWrapperViewModel> GetWrapperForIndexView(BannerFilter filter);
    }
}