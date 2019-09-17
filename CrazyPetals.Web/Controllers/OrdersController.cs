using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Abstraction.Service;
using CrazyPetals.Entities.Filters;
using CrazyPetals.Entities.WebViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CrazyPetals.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        #region Private fields and Constructor
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
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

        public IActionResult Details(int id)
        {
            return View();
        }
    }
}