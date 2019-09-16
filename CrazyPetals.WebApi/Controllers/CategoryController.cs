using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrazyPetals.Abstraction;
using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Abstraction.Service;
using CrazyPetals.Entities.Constant;
using CrazyPetals.Entities.Database;
using CrazyPetals.Entities.Resources;
using CrazyPetals.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrazyPetals.WebApi.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;
        private ICategoryRepository _categoryRepository;
        private IUnitOfWork _unitOfWork;
        private IProductImagesRepository _productImagesRepository;
        private IUserAddressRepository _userAddressRepository;
        private IOrderRepository _orderSummaryRepository;
        private IOrderDetailsRepository _orderDetailsRepository;
        private IApplicationUserRepository _applicationUserRepository;
        private IForgotPasswordRepository _forgotPasswordRepository;
        private IAppThemeRepository _appThemeRepository;
        private IEmailService _emailService;

        public CategoryController(IUserService userService, ICategoryService categoryService, IAppThemeRepository appThemeRepository, IEmailService emailService, IForgotPasswordRepository forgotPasswordRepository, ICategoryRepository categoryRepository, IApplicationUserRepository applicationUserRepository, IOrderDetailsRepository orderDetailsRepository, IOrderRepository orderSummaryRepository, IUserAddressRepository userAddressRepository, IProductImagesRepository productImagesRepository, IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _categoryService = categoryService;
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
            _productImagesRepository = productImagesRepository;
            _userAddressRepository = userAddressRepository;
            _orderSummaryRepository = orderSummaryRepository;
            _orderDetailsRepository = orderDetailsRepository;
            _applicationUserRepository = applicationUserRepository;
            _forgotPasswordRepository = forgotPasswordRepository;
            _appThemeRepository = appThemeRepository;
            _emailService = emailService;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region GetAppTheme
        /// <summary>
        /// This API returns the App Theme
        /// </summary>
        /// <returns></returns>
        [Route("api/Category/GetAppTheme")]
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAppTheme()
        {

            var response =await _categoryService.GetAppTheme();

            if (response.error == true)
            {
                return Ok(new { statusCode = StringConstants.StatusCode20, message = response.Message });
            }
            return Ok(new { statusCode = StringConstants.StatusCode10, message = response.Message, data = response.data });
        }
        #endregion


        #region GetVersionInfo
        /// <summary>
        /// This API returns Version Details
        /// </summary>
        /// <param name></param>
        /// <returns></returns>
        [Route("api/Category/GetVersionInfo")]
        [HttpGet]
        public IActionResult GetVersionInfo(string AppId)
        {
            var response = _categoryService.GetVersion(AppId);

            if (response.error == true)
            {
                return Ok(new { statusCode = StringConstants.StatusCode20, message = response.Message });
            }
            return Ok(new { statusCode = StringConstants.StatusCode10, message = response.Message, data = response.data });
        }
        #endregion


        #region GetBanners
        /// <summary>
        /// This API returns the list of banners
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("api/category/GetAllBanners")]
        [HttpGet]
        public async Task<IActionResult> GetBanners(int take, string AppId)
        {
            var response = await _categoryService.GetBanner(take,AppId);

            if (response.error == true)
            {
                return Ok(new { statusCode = StringConstants.StatusCode20, message = response.Message });
            }
            return Ok(new { statusCode = StringConstants.StatusCode10, message = response.Message, data = response.data });
        }
        #endregion


        #region GetCategories
        /// <summary>
        /// This API returns the list of categories
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("api/category/GetAllCategories")]
        [HttpGet]
        public async Task<IActionResult> GetCategories(int take, string AppId)
        {
            var response = await _categoryService.GetCategory(take, AppId);

            if (response.error == true)
            {
                return Ok(new { statusCode = StringConstants.StatusCode20, message = response.Message });
            }
            return Ok(new { statusCode = StringConstants.StatusCode10, message = response.Message, data = response.data });
        }
        #endregion


        #region GetNotifications
        /// <summary>
        /// This API returns the list of Notifications
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("api/category/GetAllNotifications")]
        [HttpGet]
        public async Task<IActionResult> GetNotifications(int take, string AppId)
        {
            var response = await _categoryService.GetNotification(take, AppId);

            if (response.error == true)
            {
                return Ok(new { statusCode = StringConstants.StatusCode20, message = response.Message });
            }
            return Ok(new { statusCode = StringConstants.StatusCode10, message = response.Message, data = response.data });
        }
        #endregion


        #region GetFilters
        /// <summary>
        /// This API returns the list of Filters
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("api/category/GetAllFilters")]
        [HttpGet]
        public async Task<IActionResult> GetFilters(int CategoryId, string AppId)
        {
            var response = await _categoryService.GetFilter(CategoryId, AppId);

            if (response.error == true)
            {
                return Ok(new { statusCode = StringConstants.StatusCode20, message = response.Message });
            }
            return Ok(new { statusCode = StringConstants.StatusCode10, message = response.Message, data = response.data });
        }
        #endregion


        #region GetProductsForSearch
        /// <summary>
        /// This API returns the list of products for search
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("api/category/GetAllProductsForSearch")]
        [HttpGet]
        public async Task<IActionResult> GetProductsForSearch(int take, string AppId,string Search)
        {
            var response = await _categoryService.GetProductListForSearch(take, AppId,Search);

            if (response.error == true)
            {
                return Ok(new { statusCode = StringConstants.StatusCode20, message = response.Message });
            }
            return Ok(new { statusCode = StringConstants.StatusCode10, message = response.Message, data = response.data });
        }
        #endregion


        #region GetProductDetails
        /// <summary>
        /// This API returns ProductDetails
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Route("api/category/GetProductDetails")]
        [HttpGet]
        public IActionResult GetProductDetails(int Id, string AppId)
        {
            var response =  _categoryService.GetProductDetail(Id, AppId);

            if (response.error == true)
            {
                return Ok(new { statusCode = StringConstants.StatusCode20, message = response.Message });
            }
            return Ok(new { statusCode = StringConstants.StatusCode10, message = response.Message, data = response.data });
        }
        #endregion

        #region GetAllProductForCategory
        /// <summary>
        /// This API returns Product List for selected Category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        [Route("api/category/GetAllProductForCategory")]
        [HttpGet]
        public IActionResult GetAllProductForCategory(int CategoryId, string AppId, int skip, int take)
        {
            var response =  _categoryService.GetAllProductForCategory(CategoryId,AppId,skip,take);

            if (response.error == true)
            {
                return Ok(new { statusCode = StringConstants.StatusCode20, message = response.Message });
            }
            return Ok(new { statusCode = StringConstants.StatusCode10, message = response.Message, data = response.data });
        }
        #endregion

        #region GetRecommendedProduct
        /// <summary>
        /// This API returns Product List for RecommendedProduct
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="ProductId"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        [Route("api/category/GetRecommendedProduct")]
        [HttpGet]
        public IActionResult GetRecommendedProduct(int CategoryId,int ProductId, string AppId, int skip, int take)
        {
            var response = _categoryService.GetRecommendedProduct(CategoryId,ProductId, AppId, skip, take);

            if (response.error == true)
            {
                return Ok(new { statusCode = StringConstants.StatusCode20, message = response.Message });
            }
            return Ok(new { statusCode = StringConstants.StatusCode10, message = response.Message, data = response.data });
        }
        #endregion
    }
}
