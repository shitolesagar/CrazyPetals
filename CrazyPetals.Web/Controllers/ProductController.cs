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
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IFileServices _fileServices;
        private readonly IFilterService _filterService;

        public ProductController(IProductService productService, IFileServices fileServices, IFilterService filterService)
        {
            _productService = productService;
            _fileServices = fileServices;
            _filterService = filterService;
        }
        public IActionResult Index(ProductFilter filter)
        {
            ViewBag.Filters = filter;
            return View();
        }

        public async Task<IActionResult> Add()
        {
            await GetDropdownData();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Add");
            model.MainImageText = await _fileServices.SaveImageAndReturnRelativePath(model.Image, FolderConstants.ProductsFolder);
            if (model.Image1 != null)
                model.Image1RelativePath = await _fileServices.SaveImageAndReturnRelativePath(model.Image1, FolderConstants.ProductsFolder);
            if (model.Image2 != null)
                model.Image2RelativePath = await _fileServices.SaveImageAndReturnRelativePath(model.Image2, FolderConstants.ProductsFolder);
            if (model.Image3 != null)
                model.Image3RelativePath = await _fileServices.SaveImageAndReturnRelativePath(model.Image3, FolderConstants.ProductsFolder);
            if (model.Image4 != null)
                model.Image4RelativePath = await _fileServices.SaveImageAndReturnRelativePath(model.Image4, FolderConstants.ProductsFolder);
            await _productService.AddProductAsync(model);
            TempData["Message"] = MessageConstants.ProductAddSuccessMessage;
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            //AddProductViewModel model = await _productService.getForEditAsync(id);
            return View();
        }

        public async Task<JsonResult> GetSubcategoryDropList(int categoryId)
        {
            List<IdNameViewModel> list = await _filterService.GetFilterListAsync(categoryId);
            return Json(list);
        }

        public async Task<IActionResult> Edit(int id)
        {
            await GetDropdownData();
            //AddProductViewModel model = await _productService.getForEditAsync(id);
            return View();
        }
        [HttpPost]
        public IActionResult Edit(int id, AddProductViewModel model)
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            int deletedRows = await _productService.DeleteProduct(id);
            if (deletedRows > 0)
                TempData["Message"] = MessageConstants.ProductDeletedSuccessMessage;
            else
                TempData["Message"] = MessageConstants.ProductDeletionFailedMessage;
            return RedirectToAction("Index");
        }


        #region Private Methods
        public async Task GetDropdownData()
        {
            List<IdNameViewModel> categoryList = await _productService.GetCategoryListAsync();
            List<IdNameViewModel> FilterList = await _productService.GetFilterListAsync();
            List<IdNameViewModel> ColorList = await _productService.GetColorListAsync();
            List<IdNameViewModel> AvailableSize = await _productService.GetAvailableSizeList();
            ViewBag.CategoryList = categoryList.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name });
            ViewBag.FiltersList = FilterList.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name });
            ViewBag.ColorList = ColorList.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name });
            ViewBag.AvaliableSizeList = AvailableSize.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name });
        }
        #endregion
    }
}