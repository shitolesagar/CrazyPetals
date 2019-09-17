
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrazyPetals.Abstraction;
using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Abstraction.Service;
using CrazyPetals.Entities.Database;
using CrazyPetals.Entities.Filters;
using CrazyPetals.Entities.WebViewModels;

namespace CrazyPetals.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IFilterRepository _filterRepository;
        private readonly IColorsRepository _colorsRepository;
        private readonly ISizeRepository _sizeRepository;

        public ProductService(IProductRepository productRepository,
            IUnitOfWork unitOfWork,
            ICategoryRepository categoryRepository,
            IFilterRepository filterRepository,
            IColorsRepository colorsRepository,
            ISizeRepository sizeRepository
            )
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
            _filterRepository = filterRepository;
            _colorsRepository = colorsRepository;
            _sizeRepository = sizeRepository;
        }


        public Task<int> AddProductAsync(AddProductViewModel model, List<string> imageUrls)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<IdNameViewModel>> GetAvailableSizeList()
        {
            var list = await _sizeRepository.GetAllAsync();
            var responseList = list.Select(x => new IdNameViewModel { Id = x.Id, Name = x.ProductSize }).ToList();
            return responseList;
        }

        public async Task<List<IdNameViewModel>> GetCategoryListAsync()
        {
            var list = await _categoryRepository.GetAllAsync();
            var responseList = list.Select(x => new IdNameViewModel { Id = x.Id, Name = x.Name }).ToList();
            return responseList;
        }

        public async Task<List<IdNameViewModel>> GetColorListAsync()
        {
            var list = await _colorsRepository.GetAllAsync();
            var responseList = list.Select(x => new IdNameViewModel { Id = x.Id, Name = x.Name }).ToList();
            return responseList;
        }

        public async Task<List<IdNameViewModel>> GetFilterListAsync()
        {
            var list = await _filterRepository.GetAllAsync();
            var responseList = list.Select(x => new IdNameViewModel { Id = x.Id, Name = x.Name }).ToList();
            return responseList;
        }

        public async Task<ProductWrapperViewModel> GetWrapperForIndexView(ProductFilter filter)
        {
            ProductWrapperViewModel ResponseModel = new ProductWrapperViewModel
            {
                TotalCount = _productRepository.GetIndexViewTotalCount(filter)
            };
            ResponseModel.PagingData = new PagingData(ResponseModel.TotalCount, filter.PageSize, filter.PageIndex);
            List<Product> list = await _productRepository.GetIndexViewRecordsAsync(filter, (filter.PageIndex - 1) * filter.PageSize, filter.PageSize);
            ResponseModel.ProductList = list.Select((x, index) => new ProductListViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CategoryName = x.Category.Name,
                Number = ResponseModel.PagingData.FromRecord + index,
            }).ToList();
            ResponseModel.PagingData = new PagingData(ResponseModel.TotalCount, filter.PageSize, filter.PageIndex);
            return ResponseModel;
        }
    }
}
