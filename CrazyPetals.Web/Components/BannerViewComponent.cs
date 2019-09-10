using CrazyPetals.Abstraction.Service;
using CrazyPetals.Entities.Database;
using CrazyPetals.Entities.Filters;
using CrazyPetals.Entities.WebViewModels;
using CrazyPetals.Service.ExtensionMethods;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrazyPetals.Web.Components
{

    public class BannerViewComponent : ViewComponent
    {
        private readonly IBannerService _bannerService;

        public BannerViewComponent(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }
        public async Task<IViewComponentResult> InvokeAsync(BannerFilter filter, bool IsPartial)
        {
            BannerWrapperViewModel ResponseModel = await _bannerService.GetWrapperForIndexView(filter);
            ViewBag.ShowEmptyState = !IsPartial;
            return View(ResponseModel);
        }
    }
}
