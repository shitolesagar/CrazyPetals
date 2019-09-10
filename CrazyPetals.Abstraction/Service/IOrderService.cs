using CrazyPetals.Entities.Filters;
using CrazyPetals.Entities.WebViewModels;
using System.Threading.Tasks;

namespace CrazyPetals.Abstraction.Service
{
    public interface IOrderService
    {
        Task<OrderWrapperViewModel> GetWrapperForIndexView(OrderFilter filter);
    }
}