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
            ViewBag.Filters = filter;
            return View();
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