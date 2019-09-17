using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrazyPetals.Abstraction.Service;
using CrazyPetals.Entities.Filters;
using CrazyPetals.Entities.WebViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CrazyPetals.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IUserService _userService;

        public CustomerController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index(FilterBase filter)
        {
            ViewBag.Filters = filter;
            return View();
        }

        public IActionResult IndexPartial(FilterBase filter)
        {
            return ViewComponent("Customer", new { filter, IsPartial = true });
        }

        public async Task<IActionResult> Details(int id)
        {
            CustomerDetailsViewModel model = await _userService.GetCustomerDetails(id);
            return View(model);
        }
    }
}