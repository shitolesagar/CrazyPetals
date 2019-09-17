
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrazyPetals.Abstraction;
using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Abstraction.Service;
using CrazyPetals.Entities.Database;
using CrazyPetals.Entities.Filters;
using CrazyPetals.Entities.WebViewModels;
using CrazyPetals.Service.ExtensionMethods;

namespace CrazyPetals.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private IUnitOfWork _unitOfWork;
        private readonly IOrderDeliveryStatusRepository _deliveryStatusRepository;

        public OrderService(IOrderRepository orderRepository , IUnitOfWork unitOfWork, IOrderDeliveryStatusRepository orderDeliveryStatusRepository)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _deliveryStatusRepository = orderDeliveryStatusRepository;
        }

        public async Task<OrderWrapperViewModel> GetWrapperForIndexView(OrderFilter filter)
        {
            OrderWrapperViewModel ResponseModel = new OrderWrapperViewModel
            {
                TotalCount = _orderRepository.GetIndexViewTotalCount(filter)
            };
            ResponseModel.PagingData = new PagingData(ResponseModel.TotalCount, filter.PageSize, filter.PageIndex);
            List<Order> list = await _orderRepository.GetIndexViewRecordsAsync(filter, (filter.PageIndex - 1) * filter.PageSize, filter.PageSize);
            ResponseModel.OrderList = list.Select((x, index) => new OrderListViewModel
            {
                Id = x.Id,
                OrderNumber = x.OrderNumber,
                Status = x.DeliveryStatus.Status,
                CreatedDate = x.CreatedDate.ToCrazyPattelsPattern(),
                Number = ResponseModel.PagingData.FromRecord + index,
            }).ToList();
            ResponseModel.PagingData = new PagingData(ResponseModel.TotalCount, filter.PageSize, filter.PageIndex);
            return ResponseModel;
        }

        public async Task<List<IdNameViewModel>> GetAllDeliveryStatusAsync()
        {
            var list = await _deliveryStatusRepository.GetAllAsync();
            var responseList = list.Select(x => new IdNameViewModel { Id = x.Id, Name = x.Status }).ToList();
            return responseList;
        }
    }
}
