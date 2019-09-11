
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
        private readonly IOrderSummaryRepository _orderSummaryRepository;
        private IUnitOfWork _unitOfWork;
        private object _FilterRepository;

        public OrderService(IOrderSummaryRepository orderSummaryRepository , IUnitOfWork unitOfWork)
        {
            _orderSummaryRepository = orderSummaryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<OrderWrapperViewModel> GetWrapperForIndexView(OrderFilter filter)
        {
            OrderWrapperViewModel ResponseModel = new OrderWrapperViewModel
            {
                TotalCount = _orderSummaryRepository.GetIndexViewTotalCount(filter)
            };
            ResponseModel.PagingData = new PagingData(ResponseModel.TotalCount, filter.PageSize, filter.PageIndex);
            List<OrderSummary> list = await _orderSummaryRepository.GetIndexViewRecordsAsync(filter, (filter.PageIndex - 1) * filter.PageSize, filter.PageSize);
            ResponseModel.OrderList = list.Select((x, index) => new OrderListViewModel
            {
                Id = x.Id,
                OrderNumber = x.Id.ToString(),
                Status = "",
                Number = ResponseModel.PagingData.FromRecord + index,
            }).ToList();
            ResponseModel.PagingData = new PagingData(ResponseModel.TotalCount, filter.PageSize, filter.PageIndex);
            return ResponseModel;
        }
    }
}
