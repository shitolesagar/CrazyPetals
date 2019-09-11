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
    public class WebCategoryService : IWebCategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private IUnitOfWork _unitOfWork;

        public WebCategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<int> AddCategoryAsync(AddCategoryViewModel model, string imageRelativePath)
        {
            Category category = new Category()
            {
                AppId = StringConstants.AppId,
                Image = imageRelativePath,
                Name = model.CategoryName,
            };
            _categoryRepository.Add(category);
            return _unitOfWork.SaveChangesAsync();
        }

        public async Task<int> DeleteCategory(int id)
        {
            Category category = _categoryRepository.FindCategoryWithoutProducts(id);
            if (category == null)
                return 0;
            else
            {
                _categoryRepository.Remove(category);
                var result = await _unitOfWork.SaveChangesAsync();
                return result;
            }
        }

        public async Task<int> EditCategoryAsync(int id, AddCategoryViewModel model, string imageRelativePath)
        {
            Category toUpdate = await _categoryRepository.FindByIdAsync(id);
            toUpdate.Name = model.CategoryName;
            if (!string.IsNullOrEmpty(imageRelativePath))
            {
                toUpdate.Image = imageRelativePath;
            }
            var result = await _unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<AddCategoryViewModel> getForEditAsync(int id)
        {
            var databaseModel = await _categoryRepository.FindByIdAsync(id);
            AddCategoryViewModel model = new AddCategoryViewModel()
            {
                CategoryName = databaseModel.Name,
                ImageUrl = databaseModel.Image
            };
            return model;
        }

        public async Task<CategoryWrapperViewModel> GetWrapperForIndexView(FilterBase filter)
        {
            CategoryWrapperViewModel ResponseModel = new CategoryWrapperViewModel
            {
                TotalCount = _categoryRepository.GetIndexViewTotalCount(filter)
            };
            ResponseModel.PagingData = new PagingData(ResponseModel.TotalCount, filter.PageSize, filter.PageIndex);
            List<Category> list = await _categoryRepository.GetIndexViewRecordsAsync(filter, (filter.PageIndex - 1) * filter.PageSize, filter.PageSize);
            ResponseModel.CategoryList = list.Select((x, index) => new CategoryListViewModel
            {
                Id = x.Id,
                Name = x.Name,
                ImagePath = x.Image,
                Number = ResponseModel.PagingData.FromRecord + index,
            }).ToList();
            ResponseModel.PagingData = new PagingData(ResponseModel.TotalCount, filter.PageSize, filter.PageIndex);
            return ResponseModel;
        }
    }
}
