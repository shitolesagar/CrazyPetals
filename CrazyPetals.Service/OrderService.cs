

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrazyPetals.Abstraction;
using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Abstraction.Service;
using CrazyPetals.Entities.Database;
using CrazyPetals.Entities.Filters;
using CrazyPetals.Entities.WebViewModels;
using CrazyPetals.Entities.WebViewModels.DetailsPageViewModels;
using CrazyPetals.Service.ExtensionMethods;

namespace CrazyPetals.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        private IUnitOfWork _unitOfWork;
        private readonly IOrderDeliveryStatusRepository _deliveryStatusRepository;

        public OrderService(IOrderRepository orderRepository , IOrderDetailsRepository orderDetailsRepository, IUnitOfWork unitOfWork, IOrderDeliveryStatusRepository orderDeliveryStatusRepository)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _deliveryStatusRepository = orderDeliveryStatusRepository;
            _orderDetailsRepository = orderDetailsRepository;
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


        public async Task<OrderDetailsViewModel> GetOrderDetails(int id)
        {
            OrderDetailsViewModel model;
            Order order = await _orderRepository.GetOrderDetails(id);
            if (order == null)
                return null;
            model = new OrderDetailsViewModel()
            {
                SubTotal = Math.Round(order.SubTotalPrice, 2),
                DiscountedPrice = Math.Round(order.DiscountPrice, 2) ,
                TotalPrice = Math.Round(order.TotalPrice, 2) ,
                GSTPrice = Math.Round(order.GSTPrice, 2) ,
                DeliveryCharges = Math.Round(order.DeliveryCharges, 2),
                OrderNumber = order.OrderNumber,
                CreatedDate = DateExtension.ToCrazyPattelsPattern(order.CreatedDate),
                ApplicationUser = order.ApplicationUser.Name,
                DeliveryStatus = order.DeliveryStatus.Status,
                PaymentStatus = order.PaymentStatus.Status,
                ShippingAddress = order.UserAddress.Address+","+order.UserAddress.Locality+","+order.UserAddress.PINCode
            };
            List<OrderDetails> Orders = _orderDetailsRepository.GetAllItemsForOrder(id);
            model.OrderDetails = Orders.Select((x, index) => new OrderDetailsModel()
            {
                OriginalPrice = x.OriginalPrice,
                DiscountedPrice = x.DiscountedPrice,
                Quantity = x.Quantity,
                ProductName = x.Product.Name,
                TotalPrice = x.DiscountedPrice*x.Quantity,
            }).ToList();
            return model;
        }
    }
}
