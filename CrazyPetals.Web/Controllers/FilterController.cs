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
        public async Task<IActionResult> Index(FilterForFilterModule filter)
        {
            ViewBag.Filters = filter;
            List<IdNameViewModel> categoryList = await _filterService.GetCategoryList();
            ViewBag.CategoriesList = categoryList.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name });

            return View();
        }

        public IActionResult IndexPartial(FilterForFilterModule filter)
        {
            return ViewComponent("Filter", new { filter, IsPartial = true });
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
                return RedirectToAction("Add");
            await _filterService.AddFilterAsync(model);
            TempData["Message"] = MessageConstants.FilterAddSuccessMessage;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            int deletedRows = await _filterService.Deletefilter(id);
            if (deletedRows > 0)
                TempData["Message"] = MessageConstants.FilterDeleteSuccessMessage;
            else
                TempData["Message"] = MessageConstants.FilterDeleteFailedMessage;
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            AddFilterViewModel model = await _filterService.getForEditAsync(id);
            if (model == null)
                return RedirectToAction("Index");
            List<IdNameViewModel> categoryList = await _filterService.GetCategoryList();
            ViewBag.CategoriesList = categoryList.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name });
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AddFilterViewModel model)
        {
            if (!ModelState.IsValid)
                return View();
            await _filterService.EditFilterAsync(id, model);
            return RedirectToAction("Index");
        }
    }
}