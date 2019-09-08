using System;
using Microsoft.AspNetCore.Mvc;

namespace CrazyPetals.Web.Controllers
{
    public class SubcategoryController : Controller
    {
        public IActionResult Index()
        {
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