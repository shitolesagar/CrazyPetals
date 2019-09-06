using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CrazyPetals.Abstraction;
using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Abstraction.Service;
using CrazyPetals.Entities.Database;
using CrazyPetals.Entities.Resources;
using CrazyPetals.Service;
using CrazyPetals.Service.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrazyPetals.WebApi.Controllers
{
    public class AccountController : Controller
    {
        private readonly string[] ACCEPTED_FILE_TYPES = new[] { ".jpg", ".jpeg", ".png" };
        private readonly IUserService _userService;
        private ICategoryRepository _categoryRepository;
        private IUnitOfWork _unitOfWork;
        private IProductImagesRepository _productImagesRepository;
        private IUserAddressRepository _userAddressRepository;
        private IOrderSummaryRepository _orderSummaryRepository;
        private IOrderDetailsRepository _orderDetailsRepository;
        private IApplicationUserRepository _applicationUserRepository;
        private IForgotPasswordRepository _forgotPasswordRepository;
        private IEmailService _emailService;

        public AccountController(IUserService userService, IEmailService emailService, IForgotPasswordRepository forgotPasswordRepository, ICategoryRepository categoryRepository, IApplicationUserRepository applicationUserRepository, IOrderDetailsRepository orderDetailsRepository, IOrderSummaryRepository orderSummaryRepository, IUserAddressRepository userAddressRepository, IProductImagesRepository productImagesRepository, IUnitOfWork unitOfWork)
        {
             _userService = userService;
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
            _productImagesRepository = productImagesRepository;
            _userAddressRepository = userAddressRepository;
            _orderSummaryRepository = orderSummaryRepository;
            _orderDetailsRepository = orderDetailsRepository;
            _applicationUserRepository = applicationUserRepository;
            _forgotPasswordRepository = forgotPasswordRepository;
            _emailService = emailService;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region Registration
        [Route("api/Account/Register")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register([FromBody] Register request)
        {
            if (string.IsNullOrEmpty(request.AppId))
                return Ok(new { statusCode = StringConstants.StatusCode20, message = StringConstants.AppIdNull });

            var response =  _userService.RegisterUser(request);

            if(response.error==true)
            {
                return Ok(new { statusCode = StringConstants.StatusCode20, message = response.Message });
            }
            return Ok(new { statusCode = StringConstants.StatusCode10, message = response.Message, data = response.data });
           
        }
        #endregion


        #region Login
        [Route("api/Account/Login")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var response = _userService.LoginUser(request);

            if (response.error == true)
            {
                return Ok(new { statusCode = StringConstants.StatusCode20, message = response.Message });
            }
            return Ok(new { statusCode = StringConstants.StatusCode10, message = response.Message });
        }

        #endregion


        #region Forgot Password (sendOtp)
        [Route("api/Account/SendOtp")]
        [AllowAnonymous]
        [HttpGet]
        public  IActionResult SendOtp([FromQuery]BaseRequest request)
        {
            var response = _userService.OTPSend(request);

            if (response.error == true)
            {
                return Ok(new { statusCode = StringConstants.StatusCode20, message = response.Message });
            }
            return Ok(new { statusCode = StringConstants.StatusCode10, message = response.Message });

        }
        #endregion

    }
}