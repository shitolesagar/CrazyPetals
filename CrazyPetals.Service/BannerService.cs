using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CrazyPetals.Abstraction;
using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Abstraction.Service;
using CrazyPetals.Entities.Constant;
using CrazyPetals.Entities.Database;
using CrazyPetals.Entities.Filters;
using CrazyPetals.Entities.WebViewModels;

namespace CrazyPetals.Service
{
    public class BannerService : IBannerService
    {
        private readonly IBannerRepository _bannerRepository;
        private IUnitOfWork _unitOfWork;

        public BannerService(IBannerRepository bannerRepository, IUnitOfWork unitOfWork)
        {
            _bannerRepository = bannerRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<int> AddBannerAsync(AddBannerViewModel model, string imageRelativePath)
        {
            Banner banner = new Banner()
            {
                AppId = StringConstants.AppId,
                CreatedDate = DateTime.Now,
                ExpiryDate = model.ExpireDate,
                Image = imageRelativePath,
                Title = model.Caption
            };
            _bannerRepository.Add(banner);
            return _unitOfWork.SaveChangesAsync();
        }

        public Task<List<Banner>> GetAdminViewBannerAsync(BannerFilters filter, int skip, int pageSize)
        {
            return _bannerRepository.PageAllAsync(skip, pageSize);
        }

        public int GetAdminViewBannerCount(BannerFilters filter)
        {
            return _bannerRepository.GetAll().Count;
        }
    }
}
