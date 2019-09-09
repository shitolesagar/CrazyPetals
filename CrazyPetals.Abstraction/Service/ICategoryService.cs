using CrazyPetals.Entities.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrazyPetals.Abstraction.Service
{
    public interface ICategoryService
    {
         Task<ApplicationThemeResponse> GetAppTheme();

         VersionResponse GetVersion(string AppId);

        Task<BannerResponse> GetBanner(int take, string AppId);

        Task<CategoryResponse> GetCategory(int take, string AppId);

        Task<NotificationResponse> GetNotification(int take, string AppId);

        Task<FilterResponse> GetFilter(int CategoryId, string AppId);

        Task<ProductResponse> GetProductListForSearch(int take, string AppId, string Search);

        ProductDetailsResponse GetProductDetail(int Id, string AppId);
    }
}
