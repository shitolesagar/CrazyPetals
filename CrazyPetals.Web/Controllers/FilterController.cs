using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrazyPetals.Abstraction.Service;
using CrazyPetals.Entities.Constant;
using CrazyPetals.Entities.Filters;
using CrazyPetals.Entities.WebViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CrazyPetals.Web.Controllers
{
    
    public class FilterController : Controller
    {
        private readonly IFilterService _filterService;

        public FilterController(IFilterService FilterService)
        {
            _filterService = FilterService;
        }
        public IActionResult Index(FilterFilter filter)
        {
            ViewBag.Filters = filter;
            return View();
        }

        public async Task<IActionResult> Add()
        {
            List<IdNameViewModel> categoryList = await _filterService.GetCategoryList();
            ViewBag.CategoriesList = categoryList.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name });
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddFilterViewModel model)
        {
            if (!ModelState.IsValid)
                return View();
            await _filterService.AddFilterAsync(model);
            TempData["Message"] = MessageConstants.FilterAddSuccessMessage;
            return RedirectToAction("Index");
        }
    }
}