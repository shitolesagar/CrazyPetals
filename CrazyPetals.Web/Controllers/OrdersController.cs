using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Abstraction.Service;
using CrazyPetals.Entities.Constant;
using CrazyPetals.Entities.Filters;
using CrazyPetals.Entities.WebViewModels;
using CrazyPetals.Entities.WebViewModels.DetailsPageViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CrazyPetals.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IOrderDeliveryStatusRepository _orderDeliveryStatusRepository;
        #region Private fields and Constructor
        public OrdersController(IOrderService orderService, IOrderDeliveryStatusRepository orderDeliveryStatusRepository)
        {
            _orderService = orderService;
            _orderDeliveryStatusRepository = orderDeliveryStatusRepository;
        }


        #endregion
        public async Task<IActionResult> Index(OrderFilter filter)
        {
            ViewBag.Filters = filter;
            List<IdNameViewModel> deliveryStatusList = await _orderService.GetAllDeliveryStatusAsync();
            ViewBag.DeliveryStatusList = deliveryStatusList.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name });
            return View();
        }

        public IActionResult IndexPartial(OrderFilter filter)
        {
            return ViewComponent("Order", new { filter, IsPartial = true });
        }

        public async Task<IActionResult> Details(int id)
        {
            List<IdNameViewModel> deliveryStatusList = await _orderService.GetAllDeliveryStatusAsync();
            ViewBag.DeliveryStatusList = deliveryStatusList.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name });
            OrderDetailsViewModel model = await _orderService.GetOrderDetails(id);
            return View(model);
        }
        public  IActionResult UpdateStatus(UpdateStatusResource filter )
        {
            string  result =  _orderService.UpdateStatus(filter);
            TempData["Message"] = MessageConstants.DeliveryStatusUpdated;
            //ViewBag.result = MessageConstants.DeliveryStatusUpdated;
            //return RedirectToAction("Index");
            return RedirectToAction("Details", new { @id = filter.Id });
        }
    }
}