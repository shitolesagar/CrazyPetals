using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrazyPetals.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrazyPetals.Web.Controllers
{
    public class DignosisController : Controller
    {
        private readonly UserService _userService;

        public DignosisController(UserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index(IFormFile file)
        {
            ViewBag.currentDirectory = System.IO.Directory.GetCurrentDirectory();
            return View();
        }

        public IActionResult CheckImagePath(string imagePath)
        {
            ViewBag.ImagePath = imagePath;
            return View();
        }

        public IActionResult RegisterUser()
        {

            return RedirectToAction("Index", "Account");
        }
    }
}