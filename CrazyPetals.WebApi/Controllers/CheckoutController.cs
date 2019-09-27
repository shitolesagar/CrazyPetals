using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrazyPetals.Abstraction;
using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Abstraction.Service;
using CrazyPetals.Entities.Constant;
using CrazyPetals.Entities.Resources;
using CrazyPetals.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrazyPetals.WebApi.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ICheckoutService _checkoutService;

        public CheckoutController(ICheckoutService checkoutService)
        {
            _checkoutService = checkoutService;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region AddToCart
        [Route("api/Checkout/AddToCart")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult AddToCart([FromBody] AddToCart request)
        {
            var response =  _checkoutService.AddToCart(request);

            if (response.error == true)
            {
                return Ok(new { statusCode = StringConstants.StatusCode20, message = response.Message });
            }
            return Ok(new { statusCode = StringConstants.StatusCode10, message = response.Message });
        }

        #endregion

        #region IncDecProductQuantity
        [Route("api/Checkout/IncDecProductQuantity")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult IncDecProductQuantity([FromBody] IncDecProductResource request)
        {
            var response = _checkoutService.IncDecProductQuantity(request);

            if (response.error == true)
            {
                return Ok(new { statusCode = StringConstants.StatusCode20, message = response.Message });
            }
            return Ok(new { statusCode = StringConstants.StatusCode10, message = response.Message });
        }

        #endregion

        #region GetCartList

        [Route("api/Checkout/GetCartList")]
        [HttpGet]
        public async Task<IActionResult> GetCartList(string AppId, int ApplicationUserId)
        {

            var response =await _checkoutService.GetCartList(AppId,ApplicationUserId);

            if (response.error == true)
            {
                return Ok(new { statusCode = StringConstants.StatusCode20, message = response.Message });
            }
            return Ok(new { statusCode = StringConstants.StatusCode10, message = response.Message,data = response.data,count=response.Count });
        }
        #endregion

        #region AddNewAddress
        [Route("api/Checkout/AddNewAddress")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult AddNewAddress([FromBody] UsersAddress request)
        {
            var response = _checkoutService.AddAddress(request);

            if (response.error == true)
            {
                return Ok(new { statusCode = StringConstants.StatusCode20, message = response.Message });
            }
            return Ok(new { statusCode = StringConstants.StatusCode10, message = response.Message });
        }

        #endregion

        #region EditAddress
        [Route("api/Checkout/EditAddress")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult EditAddress([FromBody] UsersAddress request)
        {
            var response = _checkoutService.EditAddress(request);

            if (response.error == true)
            {
                return Ok(new { statusCode = StringConstants.StatusCode20, message = response.Message });
            }
            return Ok(new { statusCode = StringConstants.StatusCode10, message = response.Message });
        }

        #endregion

        #region DeleteAddress
        [Route("api/Checkout/DeleteAddress")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult DeleteAddress([FromBody] DeleteAddressResource request)
        {
            var response = _checkoutService.DeleteAddress(request);

            if (response.error == true)
            {
                return Ok(new { statusCode = StringConstants.StatusCode20, message = response.Message });
            }
            return Ok(new { statusCode = StringConstants.StatusCode10, message = response.Message });
        }

        #endregion

        #region GetAddressList

        [Route("api/Checkout/GetAddressList")]
        [HttpGet]
        public async Task<IActionResult> GetAddressList(string AppId, int ApplicationUserId)
        {
            var response =await _checkoutService.GetAddressList(AppId,ApplicationUserId);

            if (response.error == true)
            {
                return Ok(new { statusCode = StringConstants.StatusCode20, message = response.Message });
            }
            return Ok(new { statusCode = StringConstants.StatusCode10, message = response.Message,data=response.data,Count = response.Count });
        }
        #endregion

        #region GetTotalPrice

        [Route("api/Checkout/GetTotalPrice")]
        [HttpGet]
        public async Task<IActionResult> GetTotalPrice(string AppId, int ApplicationUserId)
        {
            var response = await _checkoutService.GetPriceDetails(AppId, ApplicationUserId);

            if (response.error == true)
            {
                return Ok(new { statusCode = StringConstants.StatusCode20, message = response.Message });
            }
            return Ok(new { statusCode = StringConstants.StatusCode10, message = response.Message, data = response.data });
        }
        #endregion

        #region PlaceOrder

        [Route("api/Checkout/PlaceOrder")]
        [HttpPost]
        public async Task<IActionResult> PlaceOrder([FromBody] PlaceOrderResource request)
        {
            var response =await _checkoutService.PlaceOrder(request);

            if (response.error == true)
            {
                return Ok(new { statusCode = StringConstants.StatusCode20, message = response.Message });
            }
            return Ok(new { statusCode = StringConstants.StatusCode10, message = response.Message });
        }
        #endregion
    }
}