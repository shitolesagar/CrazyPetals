using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrazyPetals.Entities.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CrazyPetals.Web.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index(OrderFilter filter)
        {
            ViewBag.Filters = filter;
            return View();
        }
    }
}