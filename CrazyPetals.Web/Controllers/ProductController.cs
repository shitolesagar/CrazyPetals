using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrazyPetals.Entities.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CrazyPetals.Web.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index(ProductFilter filter)
        {
            ViewBag.Filters = filter;
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Object model)
        {
            return View();
        }
    }
}