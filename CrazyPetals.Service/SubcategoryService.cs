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

namespace CrazyPetals.Service
{
    public class SubcategoryService : ISubcategoryService
    {
        private readonly IFilterRepository _subcategoryRepository;
        private IUnitOfWork _unitOfWork;

        public SubcategoryService(IFilterRepository subcategoryRepository, IUnitOfWork unitOfWork)
        {
            _subcategoryRepository = subcategoryRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<int> AddSubcategoryAsync(AddSubcategoryViewModel model)
        {
            Filter subcategory = new Filter()
            {
                AppId = StringConstants.AppId,
                Name = model.SubcategoryName,
                CategoryId = model.CategoryId
            };
            _subcategoryRepository.Add(subcategory);
            return _unitOfWork.SaveChangesAsync();
        }

        public async Task<SubcategoryWrapperViewModel> GetWrapperForIndexView(SubcategoryFilter filter)
        {
            SubcategoryWrapperViewModel ResponseModel = new SubcategoryWrapperViewModel
            {
                TotalCount = _subcategoryRepository.GetIndexViewTotalCount(filter)
            };
            ResponseModel.PagingData = new PagingData(ResponseModel.TotalCount, filter.PageSize, filter.PageIndex);
            List<Filter> list = await _subcategoryRepository.GetIndexViewRecordsAsync(filter, (filter.PageIndex - 1) * filter.PageSize, filter.PageSize);
            ResponseModel.SubcateogryList = list.Select((x, index) => new SubcategoryListViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Category = x.Category.Name,
                Number = ResponseModel.PagingData.FromRecord + index,
            }).ToList();
            ResponseModel.PagingData = new PagingData(ResponseModel.TotalCount, filter.PageSize, filter.PageIndex);
            return ResponseModel;
        }
    }
}
