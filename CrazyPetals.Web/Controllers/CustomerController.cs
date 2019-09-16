using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrazyPetals.Entities.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CrazyPetals.Web.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index(FilterBase filter)
        {
            ViewBag.Filters = filter;
            return View();
        }

        public IActionResult IndexPartial(FilterBase filter)
        {
            return ViewComponent("Customer", new { filter, IsPartial = true });
        }

        public IActionResult Details(int id)
        {
            return View();
        }
    }
}