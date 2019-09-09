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
        public async Task<IViewComponentResult> InvokeAsync(BannerFilters filter, bool IsPartial)
        {
            BannerWrapperViewModel ResponseModel = new BannerWrapperViewModel
            {
                TotalCount = _bannerService.GetAdminViewBannerCount(filter)
            };
            ViewBag.ShowEmptyState = !IsPartial;
            ResponseModel.PagingData = new PagingData(ResponseModel.TotalCount, filter.PageSize, filter.PageIndex);
            List<Banner> list = await _bannerService.GetAdminViewBannerAsync(filter, (filter.PageIndex - 1) * filter.PageSize, filter.PageSize);
            ResponseModel.BannerList = list.Select((x, index) => new BannerListViewModel
            {
                Id = x.Id,
                Caption = x.Title,
                CreatedDate = x.CreatedDate.ToCrazyPattelsPattern(),
                ExpireDate = x.ExpiryDate?.ToCrazyPattelsPattern(),
                ImagePath = x.Image,
                Number = ResponseModel.PagingData.FromRecord + index,
            }).ToList();
            return View(ResponseModel);
        }
    }
}
