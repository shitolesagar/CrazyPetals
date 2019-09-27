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
    
    public class SubcategoryController : Controller
    {
        private readonly ISubcategoryService _subcategoryService;

        public SubcategoryController(ISubcategoryService SubcategoryService)
        {
            _subcategoryService = SubcategoryService;
        }
        public async Task<IActionResult> Index(SubcategoryFilter filter)
        {
            ViewBag.Filters = filter;
            List<IdNameViewModel> categoryList = await _subcategoryService.GetCategoryList();
            ViewBag.CategoriesList = categoryList.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name });

            return View();
        }

        public IActionResult IndexPartial(SubcategoryFilter filter)
        {
            return ViewComponent("Subcategory", new { filter, IsPartial = true });
        }
        public async Task<IActionResult> Add()
        {
            List<IdNameViewModel> categoryList = await _subcategoryService.GetCategoryList();
            ViewBag.CategoriesList = categoryList.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name });
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddSubcategoryViewModel model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Add");
            await _subcategoryService.AddSubcategoryAsync(model);
            TempData["Message"] = MessageConstants.SubcategoryAddSuccessMessage;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            int deletedRows = await _subcategoryService.DeleteSubcategory(id);
            if (deletedRows > 0)
                TempData["Message"] = MessageConstants.SubcategoryDeleteSuccessMessage;
            else
                TempData["Message"] = MessageConstants.SubcategoryDeleteFailedMessage;
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            AddSubcategoryViewModel model = await _subcategoryService.getForEditAsync(id);
            if (model == null)
                return RedirectToAction("Index");
            List<IdNameViewModel> categoryList = await _subcategoryService.GetCategoryList();
            ViewBag.CategoriesList = categoryList.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name });
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AddSubcategoryViewModel model)
        {
            if (!ModelState.IsValid)
                return View();
            await _subcategoryService.EditSubcategoryAsync(id, model);
            TempData["Message"] = MessageConstants.SubcategoryUpdateSuccessMessage;
            return RedirectToAction("Index");
        }
    }
}