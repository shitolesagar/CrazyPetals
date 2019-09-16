
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrazyPetals.Abstraction;
using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Abstraction.Service;
using CrazyPetals.Entities.Database;
using CrazyPetals.Entities.Filters;
using CrazyPetals.Entities.WebViewModels;

namespace CrazyPetals.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private IUnitOfWork _unitOfWork;

        public OrderService(IOrderRepository orderRepository , IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
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
                Status = x.FullfillmentStatus.Fullfillment_Status,
                CreatedDate = x.CreatedDate,
                Number = ResponseModel.PagingData.FromRecord + index,
            }).ToList();
            ResponseModel.PagingData = new PagingData(ResponseModel.TotalCount, filter.PageSize, filter.PageIndex);
            return ResponseModel;
        }
    }
}
