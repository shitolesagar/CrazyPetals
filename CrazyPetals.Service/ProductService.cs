
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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private IUnitOfWork _unitOfWork;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IFilterRepository _filterRepository;
        private readonly IColorsRepository _colorsRepository;
        private readonly ISizeRepository _sizeRepository;
        private readonly IProductColorRepository _productColorRepository;
        private readonly IProductImagesRepository _productImagesRepository;
        private readonly IProductSizeRepository _productSizeRepository;

        public ProductService(IProductRepository productRepository,
            IUnitOfWork unitOfWork,
            ICategoryRepository categoryRepository,
            IFilterRepository filterRepository,
            IColorsRepository colorsRepository,
            ISizeRepository sizeRepository,
            IProductColorRepository productColorRepository,
            IProductImagesRepository productImagesRepository,
            IProductSizeRepository productSizeRepository
            )
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
            _filterRepository = filterRepository;
            _colorsRepository = colorsRepository;
            _sizeRepository = sizeRepository;
            _productColorRepository = productColorRepository;
            _productImagesRepository = productImagesRepository;
            _productSizeRepository = productSizeRepository;
        }


        public async Task<int> AddProductAsync(AddProductViewModel model)
        {
            var databaseModel = new Product()
            {
                AppId = StringConstants.AppId,
                CategoryId = model.CategoryId,
                CreatedDate = DateTime.Now,
                DeliveryTime = model.DeliveryTime,
                Description = model.LongDescription,
                DiscountedPrice = model.DiscountedPrice,
                FilterId = model.FilterId,
                IncludedAccessories = model.Accessories,
                IsAvailable = model.IsAvailable,
                MaterialType = model.MaterialType,
                IsDeleted = false,
                IsExclusive = model.IsExclusive,
                IsPublish = model.Status.ToLower() == "publish",
                Name = model.ProductName,
                OriginalPrice = model.OriginalPrice,
                Precautions = model.PrecautionsInstructions,
                StockKeepingUnit = model.StockKeepingUnit,
                Weight = model.ProductWeight,
                Width = model.ProductWidth,
                Length = model.ProductLength,
                Height = model.ProductHeight,
                DiscountPercentage = 0,                    // here we have to calculate percentage
            };

            _productRepository.Add(databaseModel);
            var result = await _unitOfWork.SaveChangesAsync();

            // save images
            await SaveImages(model.MainImageText, databaseModel.Id, true);
            await SaveImages(model.Image1RelativePath, databaseModel.Id, false);
            await SaveImages(model.Image2RelativePath, databaseModel.Id, false);
            await SaveImages(model.Image3RelativePath, databaseModel.Id, false);
            await SaveImages(model.Image4RelativePath, databaseModel.Id, false);
            // save colors
            await SaveColors(model.SelectedColorIds, databaseModel.Id);
            //save sizes
            await SaveSizes(model.SelectedSizeIds, databaseModel.Id);
            return result;
        }

        private async Task SaveSizes(List<int> selectedSizeIds, int productId)
        {
            foreach (var sizeId in selectedSizeIds)
            {
                ProductSize size = new ProductSize()
                {
                    SizeId = sizeId,
                    ProductId = productId
                };
                _productSizeRepository.Add(size);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        private async Task SaveColors(List<int> selectedColorIds, int productId)
        {
            foreach (var colorId in selectedColorIds)
            {
                ProductColor color = new ProductColor()
                {
                    ColorsId = colorId,
                    ProductId = productId
                };
                _productColorRepository.Add(color);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        private async Task SaveImages(string imageUrl, int productId, bool isMain)
        {
            if(!string.IsNullOrEmpty(imageUrl))
            {
                ProductImages img = new ProductImages()
                {
                    Image = imageUrl,
                    IsMain = true,
                    ProductId = productId,
                    AppId = StringConstants.AppId,
                };
                _productImagesRepository.Add(img);
                await _unitOfWork.SaveChangesAsync();
            }
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

        

        public async Task<int> DeleteProduct(int id)
        {
            var record = await _productRepository.FindByIdAsync(id);
            if(record!=null)
                record.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<AddProductViewModel> getForEditAsync(int id)
        {
            Product record = await _productRepository.FindByIdAsync(id, true);
            throw new System.NotImplementedException();
        }

        
    }
}
