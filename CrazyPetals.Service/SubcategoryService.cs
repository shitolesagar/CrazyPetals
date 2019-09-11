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
    public class FilterService : IFilterService
    {
        private readonly IFilterRepository _filterRepository;
        private readonly ICategoryRepository _categoryRepository;
        private IUnitOfWork _unitOfWork;

        public FilterService(IFilterRepository FilterRepository,ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _filterRepository = FilterRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<int> AddFilterAsync(AddFilterViewModel model)
        {
            Filter Filter = new Filter()
            {
                AppId = StringConstants.AppId,
                Name = model.FilterName,
                CategoryId = model.CategoryId
            };
            _filterRepository.Add(Filter);
            return _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<IdNameViewModel>> GetCategoryList()
        {
            var list = await _categoryRepository.GetAllAsync();
            var responseList = list.Select(x => new IdNameViewModel { Id = x.Id, Name = x.Name }).ToList();
            return responseList;
        }

        public async Task<FilterWrapperViewModel> GetWrapperForIndexView(FilterFilter filter)
        {
            FilterWrapperViewModel ResponseModel = new FilterWrapperViewModel
            {
                TotalCount = _filterRepository.GetIndexViewTotalCount(filter)
            };
            ResponseModel.PagingData = new PagingData(ResponseModel.TotalCount, filter.PageSize, filter.PageIndex);
            List<Filter> list = await _filterRepository.GetIndexViewRecordsAsync(filter, (filter.PageIndex - 1) * filter.PageSize, filter.PageSize);
            ResponseModel.SubcateogryList = list.Select((x, index) => new FilterListViewModel
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
