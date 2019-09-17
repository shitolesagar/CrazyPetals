using CrazyPetals.Entities.Filters;
using CrazyPetals.Entities.WebViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrazyPetals.Abstraction.Service
{
    public interface IOrderService
    {
        Task<OrderWrapperViewModel> GetWrapperForIndexView(OrderFilter filter);
        Task<List<IdNameViewModel>> GetAllDeliveryStatusAsync();
    }
}