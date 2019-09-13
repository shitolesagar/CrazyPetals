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
   
    public class FilterViewComponent : ViewComponent
    {
        private readonly IFilterService _FilterService;

        public FilterViewComponent(IFilterService FilterService)
        {
            _FilterService = FilterService;
        }
        public async Task<IViewComponentResult> InvokeAsync(FilterForFilterModule filter, bool IsPartial)
        {
            FilterWrapperViewModel ResponseModel = await _FilterService.GetWrapperForIndexView(filter);
            ViewBag.ShowEmptyState = !IsPartial;
            return View(ResponseModel);
        }
    }
}
