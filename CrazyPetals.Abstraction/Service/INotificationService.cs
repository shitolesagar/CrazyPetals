using CrazyPetals.Entities.Filters;
using CrazyPetals.Entities.WebViewModels;
using System.Threading.Tasks;

namespace CrazyPetals.Abstraction.Service
{
    public interface INotificationService
    {
        Task<int> AddNotificationAsync(AddNotificationViewModel model);
        Task<NotificationWrapperViewModel> GetWrapperForIndexView(FilterBase filter);
        Task<int> DeleteNotification(int id);
    }
}