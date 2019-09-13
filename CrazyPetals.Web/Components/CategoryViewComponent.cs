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
   
    public class CategoryViewComponent : ViewComponent
    {
        private readonly IWebCategoryService _webCategoryService;

        public CategoryViewComponent(IWebCategoryService webCategoryService)
        {
            _webCategoryService = webCategoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync(FilterBase filter)
        {
            CategoryWrapperViewModel ResponseModel = await _webCategoryService.GetWrapperForIndexView(filter);
            return View(ResponseModel);
        }
    }
}
