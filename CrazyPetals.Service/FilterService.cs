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
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly ICategoryRepository _categoryRepository;
        private IUnitOfWork _unitOfWork;

        public SubcategoryService(ISubcategoryRepository SubcategoryRepository,ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _subcategoryRepository = SubcategoryRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<int> AddSubcategoryAsync(AddSubcategoryViewModel model)
        {
            Subcategory Subcategory = new Subcategory()
            {
                AppId = StringConstants.AppId,
                Name = model.SubcategoryName,
                CategoryId = model.CategoryId
            };
            _subcategoryRepository.Add(Subcategory);
            return _unitOfWork.SaveChangesAsync();
        }

        public Task<int> DeleteSubcategory(int id)
        {
            var subcategoryToDelete = _subcategoryRepository.FindById(id);
            _subcategoryRepository.Remove(subcategoryToDelete);
            return _unitOfWork.SaveChangesAsync();
        }

        public async Task<AddSubcategoryViewModel> getForEditAsync(int id)
        {
            var subcategoryToEdit = await _subcategoryRepository.FindByIdAsync(id);
            if (subcategoryToEdit == null)
                return null;
            AddSubcategoryViewModel model = new AddSubcategoryViewModel()
            {
                CategoryId = subcategoryToEdit.CategoryId,
                SubcategoryName = subcategoryToEdit.Name
            };
            return model;
        }

        public async Task EditSubcategoryAsync(int id, AddSubcategoryViewModel model)
        {
            var subcategoryToEdit = await _subcategoryRepository.FindByIdAsync(id);
            subcategoryToEdit.Name = model.SubcategoryName;
            subcategoryToEdit.CategoryId = model.CategoryId;
            await _unitOfWork.SaveChangesAsync();
        }

       

        public async Task<List<IdNameViewModel>> GetCategoryList()
        {
            var list = await _categoryRepository.GetAllAsync();
            var responseList = list.Select(x => new IdNameViewModel { Id = x.Id, Name = x.Name }).ToList();
            return responseList;
        }

        

        public async Task<SubcategoryWrapperViewModel> GetWrapperForIndexView(SubcategoryFilter filter)
        {
            SubcategoryWrapperViewModel ResponseModel = new SubcategoryWrapperViewModel
            {
                TotalCount = _subcategoryRepository.GetIndexViewTotalCount(filter)
            };
            ResponseModel.PagingData = new PagingData(ResponseModel.TotalCount, filter.PageSize, filter.PageIndex);
            List<Subcategory> list = await _subcategoryRepository.GetIndexViewRecordsAsync(filter, (filter.PageIndex - 1) * filter.PageSize, filter.PageSize);
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

        public async Task<List<IdNameViewModel>> GetSubcategoryListAsync(int categoryId)
        {
            var subcategories = await _subcategoryRepository.GetAllAsync();
            var list = subcategories.Where(x => x.CategoryId == categoryId);
            var responseList = list.Select(x => new IdNameViewModel { Id = x.Id, Name = x.Name }).ToList();
            return responseList;
        }
    }
}
