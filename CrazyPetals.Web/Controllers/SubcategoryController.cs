using System;
using System.Threading.Tasks;
using CrazyPetals.Abstraction.Service;
using CrazyPetals.Entities.Constant;
using CrazyPetals.Entities.Filters;
using CrazyPetals.Entities.WebViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CrazyPetals.Web.Controllers
{
    
    public class SubcategoryController : Controller
    {
        private readonly ISubcategoryService _subcategoryService;

        public SubcategoryController(ISubcategoryService subcategoryService)
        {
            _subcategoryService = subcategoryService;
        }
        public IActionResult Index(SubcategoryFilter filter)
        {
            ViewBag.Filters = filter;
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddSubcategoryViewModel model)
        {
            if (!ModelState.IsValid)
                return View();
            await _subcategoryService.AddSubcategoryAsync(model);
            TempData["Message"] = MessageConstants.SubcategoryAddSuccessMessage;
            return RedirectToAction("Index");
        }
    }
}