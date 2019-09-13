using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrazyPetals.Abstraction.Service;
using CrazyPetals.Entities.Constant;
using CrazyPetals.Entities.Filters;
using CrazyPetals.Entities.WebViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CrazyPetals.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IWebCategoryService _categoryService;
        private readonly IFileServices _fileServices;

        public CategoryController(IWebCategoryService categoryService, IFileServices fileServices)
        {
            _categoryService = categoryService;
            _fileServices = fileServices;
        }
        public IActionResult Index(FilterBase filter)
        {
            ViewBag.Filters = filter;
            return View();
        }

        public IActionResult IndexPartial(FilterBase filter)
        {
            return ViewComponent("Category", new { filter });
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCategoryViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            string relativePath = await _fileServices.SaveImageAndReturnRelativePath(model.File, FolderConstants.CategoriesFolder);
            await _categoryService.AddCategoryAsync(model, relativePath);
            TempData["Message"] = MessageConstants.CategoryAddSuccessMessage;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            int deletedRows = await _categoryService.DeleteCategory(id);
            if(deletedRows >0 )
                TempData["Message"] = MessageConstants.CategoryDeleteSuccessMessage;
            else
                TempData["Message"] = MessageConstants.CategoryDeleteFailedMessage;
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit (int id)
        {
            
            AddCategoryViewModel model = await _categoryService.getForEditAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AddCategoryViewModel model)
        {
            if (!ModelState.IsValid)
                return View();
            string relativePath = string.Empty;
            if (model.File != null)
                 relativePath = await _fileServices.SaveImageAndReturnRelativePath(model.File, FolderConstants.CategoriesFolder);
            await _categoryService.EditCategoryAsync(id, model, relativePath);
            return RedirectToAction("Index");
        }
    }
}