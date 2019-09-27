using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrazyPetals.Abstraction;
using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Abstraction.Service;
using CrazyPetals.Entities.Database;
using CrazyPetals.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrazyPetals.Web.Controllers
{
    public class DignosisController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationUserRepository _applicationUserRepository;

        public DignosisController(IUserService userService, IUnitOfWork unitOfWork, IApplicationUserRepository applicationUserRepository)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
            _applicationUserRepository = applicationUserRepository;
        }
        public IActionResult Index(IFormFile file)
        {
            ViewBag.currentDirectory = System.IO.Directory.GetCurrentDirectory();
            return View();
        }

        public IActionResult CheckImagePath(string imagePath)
        {
            ViewBag.ImagePath = imagePath;
            return View();
        }
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAdmin()
        {
            var user = _applicationUserRepository.FindByEmail("admin@gmail.com");
            if (user == null)
            {
                ApplicationUser AdminUser = new ApplicationUser()
                {
                    Name = "Admin",
                    Email = "admin@gmail.com",
                    CreatedDate = DateTime.Now,
                    MobileNumber = "9423237999",
                    RoleId = 1
                };
                using (var hmac = new System.Security.Cryptography.HMACSHA512())
                {
                    AdminUser.PasswordSalt = hmac.Key;
                    AdminUser.PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes("Reset1234"));
                }
                _applicationUserRepository.Add(AdminUser);
                await _unitOfWork.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Account");
        }
    }
}