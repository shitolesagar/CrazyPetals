using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Entities.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CrazyPetals.Web.Controllers
{
    public class OrdersController : Controller
    {
        #region Private fields and Constructor
        private readonly IFullfillmentStatusRepository _fullfillmentStatusRepository;
        

        public OrdersController(IFullfillmentStatusRepository _fullfillmentStatusRepository)
        {
            
            this._fullfillmentStatusRepository = _fullfillmentStatusRepository;
            
        }


        #endregion
        public IActionResult Index(OrderFilter filter)
        {
            ViewBag.FullfillmentStatusList = _fullfillmentStatusRepository.GetAll().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Fullfillment_Status });
            ViewBag.Filters = filter;
            return View();
        }
        public IActionResult IndexPartial(OrderFilter filter)
        {
            return ViewComponent("Order", new { filter, IsPartial = true });
        }
    }
}