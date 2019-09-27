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
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        public IActionResult Index(FilterBase filter)
        {
            ViewBag.Filters = filter;
            return View();
        }

        public IActionResult IndexPartial(FilterBase filter)
        {
            return ViewComponent("Notification", new { filter });
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddNotificationViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            int result = await _notificationService.AddNotificationAsync(model);
            TempData["Message"] = MessageConstants.NotificationAddSuccessMessage;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            int deletedRows = await _notificationService.DeleteNotification(id);
            if (deletedRows > 0)
                TempData["Message"] = MessageConstants.NotificationDeleteSuccessMessage;
            else
                TempData["Message"] = MessageConstants.NotificationDeleteFailedMessage;
            return RedirectToAction("Index");
        }
    }
}