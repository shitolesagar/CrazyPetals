using CrazyPetals.Entities.Filters;
using CrazyPetals.Entities.WebViewModels;
using CrazyPetals.Entities.WebViewModels.DetailsPageViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrazyPetals.Abstraction.Service
{
    public interface IOrderService
    {
        Task<OrderWrapperViewModel> GetWrapperForIndexView(OrderFilter filter);
        Task<List<IdNameViewModel>> GetAllDeliveryStatusAsync();
        Task<OrderDetailsViewModel> GetOrderDetails(int id);
    }
}