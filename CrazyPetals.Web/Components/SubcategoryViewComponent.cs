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
   
    public class SubcategoryViewComponent : ViewComponent
    {
        private readonly ISubcategoryService _subcategoryService;

        public SubcategoryViewComponent(ISubcategoryService subcategoryService)
        {
            _subcategoryService = subcategoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync(SubcategoryFilter filter, bool IsPartial)
        {
            SubcategoryWrapperViewModel ResponseModel = await _subcategoryService.GetWrapperForIndexView(filter);
            ViewBag.ShowEmptyState = !IsPartial;
            return View(ResponseModel);
        }
    }
}
