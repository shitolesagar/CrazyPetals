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
    public class AdvertisementBannerController : Controller
    {
        private readonly IFileServices _fileServices;
        private readonly IBannerService _bannerService;

        public AdvertisementBannerController(IFileServices fileServices, IBannerService bannerService)
        {
            _fileServices = fileServices;
            _bannerService = bannerService;
        }
        public IActionResult Index(BannerFilter filter)
        {
            if (filter.showExpired || filter.showInActive)
                ViewBag.IsPartial = true;
            else
                ViewBag.IsPartial = false;
            ViewBag.Filters = filter;
            if (filter.showInActive)
                ViewBag.ddlStausSelected = "InActive";
            else if (filter.showExpired)
                ViewBag.ddlStausSelected = "Expired";
            else
                ViewBag.ddlStausSelected = "Active";
            return View();
        }

        public IActionResult IndexPartial(BannerFilter filter)
        {
            return ViewComponent("Banner", new { filter, IsPartial = true });
        }
         
        [HttpPost]
        public async Task<IActionResult> DeleteAsync(int id, BannerFilter filter)
        {
            int deletedRows = await _bannerService.DeleteBanner(id);
            if (deletedRows > 0)
                TempData["Message"] = MessageConstants.BannerDeleteSuccessMessage;
            else
                TempData["Message"] = MessageConstants.BannerDeleteFailedMessage;
            return RedirectToAction("Index", new { filter.showExpired, filter.showInActive });
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBannerViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            string relativePath = await _fileServices.SaveImageAndReturnRelativePath(model.File, FolderConstants.BannerFolder);
            await _bannerService.AddBannerAsync(model, relativePath);
            TempData["Message"] = MessageConstants.BannerAddSuccessMessage;
            return RedirectToAction("Index");
        }
    }
}