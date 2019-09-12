using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CrazyPetals.Abstraction;
using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Abstraction.Service;
using CrazyPetals.Entities.Constant;
using CrazyPetals.Entities.Database;
using CrazyPetals.Entities.Filters;
using CrazyPetals.Entities.WebViewModels;
using CrazyPetals.Service.ExtensionMethods;

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

        public Task<int> DeleteBanner(int id)
        {
            var bannerToDelete = _bannerRepository.FindById(id);
            _bannerRepository.Remove(bannerToDelete);
            return _unitOfWork.SaveChangesAsync();
        }

        public async Task<BannerWrapperViewModel> GetWrapperForIndexView(BannerFilter filter)
        {
            BannerWrapperViewModel ResponseModel = new BannerWrapperViewModel
            {
                TotalCount = _bannerRepository.GetIndexViewTotalCount(filter)
            };
            ResponseModel.PagingData = new PagingData(ResponseModel.TotalCount, filter.PageSize, filter.PageIndex);
            List<Banner> list = await _bannerRepository.GetIndexViewRecordsAsync(filter, (filter.PageIndex - 1) * filter.PageSize, filter.PageSize);
            ResponseModel.BannerList = list.Select((x, index) => new BannerListViewModel
            {
                Id = x.Id,
                Caption = x.Title,
                CreatedDate = x.CreatedDate.ToCrazyPattelsPattern(),
                ExpireDate = x.ExpiryDate?.ToCrazyPattelsPattern(),
                ImagePath = x.Image,
                Number = ResponseModel.PagingData.FromRecord + index,
                IsExpired = filter.showExpired
            }).ToList();
            ResponseModel.PagingData = new PagingData(ResponseModel.TotalCount, filter.PageSize, filter.PageIndex);
            return ResponseModel;
        }
    }
}
