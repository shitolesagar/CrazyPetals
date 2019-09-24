
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
            if (!string.IsNullOrEmpty(imageUrl))
            {
                ProductImages img = new ProductImages()
                {
                    Image = imageUrl,
                    IsMain = isMain,
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

        public async Task<List<IdNameViewModel>> GetFilterListForProductEditAsync(int categorId)
        {
            var list = await _filterRepository.GetAllAsync();
            var responseList = list.Where(x => x.CategoryId == categorId).Select(x => new IdNameViewModel { Id = x.Id, Name = x.Name }).ToList();
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
                PublishStatus = x.IsPublish ? "Published" : "Unpublished",
                Number = ResponseModel.PagingData.FromRecord + index,
                FilterName = x.Filter?.Name
            }).ToList();
            ResponseModel.PagingData = new PagingData(ResponseModel.TotalCount, filter.PageSize, filter.PageIndex);
            return ResponseModel;
        }



        public async Task<int> DeleteProduct(int id)
        {
            var record = await _productRepository.FindByIdAsync(id);
            if (record != null)
                record.IsDeleted = true;
            var result = await _unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<ProductDetailsViewModel> GetForDetailsAsync(int id)
        {
            ProductDetailsViewModel response;
            Product record = await _productRepository.FindByIdAsync(id, true);
            if (record != null)
            {
                response = new ProductDetailsViewModel()
                {
                    Id = record.Id,
                    Accessories = record.IncludedAccessories,
                    AddedOn = record.CreatedDate.ToCrazyPattelsPattern(),
                    CategoryName = record.Category.Name,
                    DeliveryTime = record.DeliveryTime,
                    FilterName = record.Filter?.Name,
                    IsAvailable = record.IsAvailable ? "Yes" : "No",
                    IsExclusive = record.IsExclusive ? "Yes" : "No",
                    LongDescription = record.Description,
                    MaterialType = record.MaterialType,
                    PrecautionsInstructions = record.Precautions,
                    ProductHeight = record.Height,
                    ProductLength = record.Length,
                    ProductName = record.Name,
                    StockKeepingUnit = record.StockKeepingUnit,
                    Status = record.IsPublish ? "Published" : "Not Published",
                    ProductWeight = record.Weight,
                    ProductWidth = record.Width,
                };
                if (record.OriginalPrice != null)
                    response.OriginalPrice = string.Format("{0:0.00}", record.OriginalPrice);
                response.DiscountedPrice = string.Format("{0:0.00}", record.DiscountedPrice);
                foreach (var image in record.ProductImages)
                {
                    if (image.IsMain)
                        response.MainImageUrl = image.Image;
                    else
                        response.ImagesPaths.Add(image.Image);
                }

                if (record.ProductColors.Count > 0)
                {
                    var colorsArray = record.ProductColors.Select(x => x.Colors.Name).ToArray();
                    response.AvailableColors = string.Join(", ", colorsArray);
                }

                if (record.ProductSizes.Count > 0)
                {
                    var sizeArray = record.ProductSizes.Select(x => x.Size.ProductSize).ToArray();
                    response.AvailableSizes = string.Join(", ", sizeArray);
                }


                return response;
            }
            return null;
        }

        public async Task<AddProductViewModel> GetForEditAsync(int id)
        {
            AddProductViewModel response;
            Product record = await _productRepository.FindByIdAsync(id, true);
            if (record != null)
            {
                response = new AddProductViewModel()
                {
                    Id = record.Id,
                    Accessories = record.IncludedAccessories,
                    CategoryId = record.CategoryId,
                    DeliveryTime = record.DeliveryTime,
                    FilterId = record.FilterId,
                    IsAvailable = record.IsAvailable,
                    IsExclusive = record.IsExclusive,
                    LongDescription = record.Description,
                    MaterialType = record.MaterialType,
                    PrecautionsInstructions = record.Precautions,
                    ProductHeight = record.Height,
                    ProductLength = record.Length,
                    ProductName = record.Name,
                    StockKeepingUnit = record.StockKeepingUnit,
                    Status = record.IsPublish ? "Publish" : "Unpublish",
                    ProductWeight = record.Weight,
                    ProductWidth = record.Width,
                };
                if (record.OriginalPrice != null)
                    response.OriginalPrice = decimal.Round(record.OriginalPrice.Value);
                response.DiscountedPrice = decimal.Round(record.DiscountedPrice);
                response.MainImageText = record.ProductImages.FirstOrDefault(x => x.IsMain == true)?.Image;
                response.SelectedColorIds = record.ProductColors.Select(x => x.ColorsId).ToList();
                response.SelectedSizeIds = record.ProductSizes.Select(x => x.SizeId).ToList();

                foreach (var img in record.ProductImages)
                {
                    if (img.IsMain != true)
                    {
                        IdNameViewModel model = new IdNameViewModel()
                        {
                            Id = img.Id,
                            Name = img.Image
                        };
                        response.EditViewImageList.Add(model);
                    }
                    else
                    {
                        response.MainImageText = img.Image;
                        response.MainImageId = img.Id;
                    }
                }

                return response;
            }
            return null;
        }

        public async Task<int> EditProductSaveAsync(int id, AddProductViewModel model)
        {
            Product databaseModel = await _productRepository.FindByIdAsync(id);
            if (databaseModel != null)
            {
                databaseModel.CategoryId = model.CategoryId;
                databaseModel.DeliveryTime = model.DeliveryTime;
                databaseModel.Description = model.LongDescription;
                databaseModel.DiscountedPrice = model.DiscountedPrice;
                databaseModel.FilterId = model.FilterId;
                databaseModel.IncludedAccessories = model.Accessories;
                databaseModel.IsAvailable = model.IsAvailable;
                databaseModel.MaterialType = model.MaterialType;
                databaseModel.IsExclusive = model.IsExclusive;
                databaseModel.IsPublish = model.Status.ToLower() == "publish";
                databaseModel.Name = model.ProductName;
                databaseModel.OriginalPrice = model.OriginalPrice;
                databaseModel.Precautions = model.PrecautionsInstructions;
                databaseModel.StockKeepingUnit = model.StockKeepingUnit;
                databaseModel.Weight = model.ProductWeight;
                databaseModel.Width = model.ProductWidth;
                databaseModel.Length = model.ProductLength;
                databaseModel.Height = model.ProductHeight;
                databaseModel.DiscountPercentage = 0;                    // here we have to calculate percentage
            }
            var result = await _unitOfWork.SaveChangesAsync();

            await RemoveDeletedImages(model.DeleteIds);

            if (model.Image != null)
                await SaveImages(model.MainImageText, databaseModel.Id, true);
            if (model.Image1 != null)
                await SaveImages(model.Image1RelativePath, databaseModel.Id, false);
            if (model.Image2 != null)
                await SaveImages(model.Image2RelativePath, databaseModel.Id, false);
            if (model.Image3 != null)
                await SaveImages(model.Image3RelativePath, databaseModel.Id, false);
            if (model.Image4 != null)
                await SaveImages(model.Image4RelativePath, databaseModel.Id, false);
            // save colors

            await RemovePreviousSavedColor(id);
            await SaveColors(model.SelectedColorIds, databaseModel.Id);
            //save sizes
            await RemovePreviousSavedSize(id);
            await SaveSizes(model.SelectedSizeIds, databaseModel.Id);
            return result;
        }

        private async Task RemovePreviousSavedSize(int productId)
        {
            var sizes = await _productSizeRepository.GetAllAsync(productId);
            foreach (var item in sizes)
            {
                _productSizeRepository.Remove(item);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        private async Task RemovePreviousSavedColor(int productId)
        {
            var colors = await _productColorRepository.GetAllAsync(productId);
            foreach (var item in colors)
            {
                _productColorRepository.Remove(item);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        private async Task RemoveDeletedImages(string deleteIds)
        {
            if (deleteIds != null)
            {
                var deleteIdsArray = deleteIds.Split(',');
                foreach (var id in deleteIdsArray)
                {
                    if (!string.IsNullOrEmpty(id))
                    {
                        var record = _productImagesRepository.FindById(int.Parse(id));
                        if (record != null)
                        {
                            _productImagesRepository.Remove(record);
                            await _unitOfWork.SaveChangesAsync();
                        }
                    }
                }
            }
        }
    }
}
