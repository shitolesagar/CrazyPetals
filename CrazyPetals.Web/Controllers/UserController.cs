using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrazyPetals.Entities.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CrazyPetals.Web.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index(UserFilter filter)
        {
            ViewBag.Filters = filter;
            return View();
        }
    }
}