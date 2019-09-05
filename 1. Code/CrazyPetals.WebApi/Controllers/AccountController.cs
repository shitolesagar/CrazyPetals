using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CrazyPetals.Abstraction;
using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Entities.Database;
using CrazyPetals.Entities.Resources;
using CrazyPetals.Service.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrazyPetals.WebApi.Controllers
{
    public class AccountController : Controller
    {
        private ICategoryRepository _categoryRepository;
        private IUnitOfWork _unitOfWork;
        private IProductImagesRepository _productImagesRepository;
        private IApplicationUserRepository _applicationUserRepository;

        private readonly string[] ACCEPTED_FILE_TYPES = new[] { ".jpg", ".jpeg", ".png" };

        public AccountController(ICategoryRepository categoryRepository, IApplicationUserRepository applicationUserRepository, IProductImagesRepository productImagesRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
            _productImagesRepository = productImagesRepository;
            _applicationUserRepository = applicationUserRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region Registration
        [Route("api/Account/Register")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] Register request)
        {
            var user = _applicationUserRepository.FindByEmail(request.EmailId);
            try
            {
                if (user != null)
                {
                    return Ok(new { statusCode = StringConstants.StatusCode20, message = StringConstants.UserExist });
                }
                else
                {
                    if (request.AppId != null)
                    {
                        user = new ApplicationUser
                        {
                            Name = request.Name,
                            Email = request.EmailId,
                            AppId = request.AppId,
                        };
                    }
                    else
                    {
                        return Ok(new { statusCode = StringConstants.StatusCode20, message = StringConstants.AppIdNull });
                    }
                    if (!string.IsNullOrEmpty(request.Password))
                    {
                        CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

                        user.PasswordHash = passwordHash;
                        user.PasswordSalt = passwordSalt;
                        user.CreatedDate = DateTime.Now;
                    }
                    _applicationUserRepository.Add(user);
                    await _unitOfWork.SaveChangesAsync();
                    var obj = new RegisterApiResponseResource
                    {
                        Id = user.Id,
                        Name = user.Name,
                        Email = user.Email,
                    };
                    return Ok(new { statusCode = StringConstants.StatusCode10, message = StringConstants.UserSaved, data = obj });
                }
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                return Ok(new { statusCode = StringConstants.StatusCode20, message = StringConstants.ServerError });
            }
        }
        #endregion

        #region PrivateMethos
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        #endregion

    }
}