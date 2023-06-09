﻿using CrazyPetals.Abstraction;
using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Abstraction.Service;
using CrazyPetals.Entities.Constant;
using CrazyPetals.Entities.Database;
using CrazyPetals.Entities.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyPetals.Service
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private IUnitOfWork _unitOfWork;
        private IEmailService _emailService;
        private IProductImagesRepository _productImagesRepository;
        private IUserAddressRepository _userAddressRepository;
        private IOrderRepository _orderSummaryRepository;
        private IOrderDetailsRepository _orderDetailsRepository;
        private IApplicationUserRepository _applicationUserRepository;
        private IForgotPasswordRepository _forgotPasswordRepository;
        private IAppThemeRepository _appThemeRepository;
        private IVersionControlRepository _versionControlRepository;
        private IBannerRepository _bannerRepository;
        private INotificationRepository _notificationRepository;
        private ISubcategoryRepository _filterRepository;
        private IProductRepository _productRepository;


        public CategoryService(ICategoryRepository categoryRepository, IProductRepository productRepository, ISubcategoryRepository filterRepository, INotificationRepository notificationRepository, IBannerRepository bannerRepository, IVersionControlRepository versionControlRepository, IAppThemeRepository appThemeRepository, IEmailService emailService, IForgotPasswordRepository forgotPasswordRepository, IApplicationUserRepository applicationUserRepository, IOrderDetailsRepository orderDetailsRepository, IOrderRepository orderSummaryRepository, IUserAddressRepository userAddressRepository, IProductImagesRepository productImagesRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
            _productImagesRepository = productImagesRepository;
            _userAddressRepository = userAddressRepository;
            _orderSummaryRepository = orderSummaryRepository;
            _orderDetailsRepository = orderDetailsRepository;
            _applicationUserRepository = applicationUserRepository;
            _forgotPasswordRepository = forgotPasswordRepository;
            _appThemeRepository = appThemeRepository;
            _emailService = emailService;
            _versionControlRepository = versionControlRepository;
            _bannerRepository = bannerRepository;
            _notificationRepository = notificationRepository;
            _filterRepository = filterRepository;
            _productRepository = productRepository;
        }

        public CategoryService()
        {

        }

        #region GetAppTheme
        public async Task<ApplicationThemeResponse> GetAppTheme()
        {
            ApplicationThemeResponse res = new ApplicationThemeResponse();
            var appConfigs = await _appThemeRepository.GetAllAsync();
            var appConfig = appConfigs.LastOrDefault<AppTheme>();
            var appTheme = new AppThemeResponse()
            {
                PrimaryColor = appConfig.PrimaryColor,
                SecondryColor = appConfig.SecondryColor,
                StatusBarColor = appConfig.StatusBarColor,
                TertiaryColor = appConfig.TertiaryColor,
                TextColor = appConfig.TextColor,
                AppName = appConfig.AppName,
                AppLogoURL = EnvironmentConstants.CPImageUrl + appConfig.AppLogo,
                CurrencySymbol = appConfig.CurrencySymbols

            };
            res.Message = StringConstants.Success;
            res.data = appTheme;
            return res;
        }
        #endregion


        #region VersionInfo
        public VersionResponse GetVersion(string AppId)
        {
            VersionResponse res = new VersionResponse();
            try
            {
                var model = _versionControlRepository.CurrentVersion(AppId);
                res.Message = StringConstants.Message;
                res.data = model;
                return res;
            }
            catch (Exception e)
            {
                res.error = true;
                res.Message = StringConstants.ServerError;
                return res;
            }
        }
        #endregion


        #region GetAllBanner
        public async Task<BannerResponse> GetBanner(int take, string AppId)
        {
            BannerResponse res = new BannerResponse();
            try
            {
                var data = await _bannerRepository.GetBannerList(0, take, AppId);
                BannerResourceWrapper response = new BannerResourceWrapper
                {
                    BannerList = new List<BannerResource>()
                };
                response.BannerList = data.Select(x => new BannerResource()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Image = EnvironmentConstants.CPImageUrl + x.Image

                }).ToList();
                res.Message = StringConstants.Message;
                res.data = response;
                return res;
            }
            catch (Exception e)
            {
                res.error = true;
                res.Message = StringConstants.ServerError;
                return res;
            }
        }
        #endregion


        #region GetAllCategory
        public async Task<CategoryResponse> GetCategory(int take, string AppId)
        {
            CategoryResponse res = new CategoryResponse();
            try
            {
                var data = await _categoryRepository.GetCategoryList(0, take, AppId);
                CategoryResourceWrapper response = new CategoryResourceWrapper
                {
                    CategoryList = new List<CategoryResource>()
                };
                response.CategoryList = data.Select(x => new CategoryResource()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Image = EnvironmentConstants.CPImageUrl + x.Image

                }).ToList();
                res.Message = StringConstants.Message;
                res.data = response;
                return res;
            }
            catch (Exception e)
            {
                res.error = true;
                res.Message = StringConstants.ServerError;
                return res;
            }
        }
        #endregion


        #region GetAllNotifications
        public async Task<NotificationResponse> GetNotification(int take, string AppId)
        {
            NotificationResponse res = new NotificationResponse();
            try
            {
                var data = await _notificationRepository.GetNotificationList(0, take, AppId);
                NotificationResourceWrapper response = new NotificationResourceWrapper
                {
                    NotificationList = new List<NotificationResource>()
                };
                response.NotificationList = data.Select(x => new NotificationResource()
                {
                    Id = x.Id,
                    Message = x.Message,
                    Title = x.Title

                }).ToList();
                res.Message = StringConstants.Message;
                res.data = response;
                return res;
            }
            catch (Exception e)
            {
                res.error = true;
                res.Message = StringConstants.ServerError;
                return res;
            }
        }
        #endregion


        #region GetAllFilters
        public async Task<FilterResponse> GetFilter(int CategoryId, string AppId)
        {
            FilterResponse res = new FilterResponse();
            try
            {
                if (CategoryId == 0)
                {
                    res.error = true;
                    res.Message = StringConstants.CatNotFound;
                    return res;
                }
                var data = await _filterRepository.GetSubcategoryAsync(CategoryId, AppId);
                FilterResourceWrapper response = new FilterResourceWrapper
                {
                    FilterList = new List<FilterResource>()
                };
                response.FilterList = data.Select(x => new FilterResource()
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToList();
                res.Message = StringConstants.Message;
                res.data = response;
                return res;
            }
            catch (Exception e)
            {
                res.error = true;
                res.Message = StringConstants.ServerError;
                return res;
            }
        }
        #endregion


        #region GetProductListForSearch
        public async Task<ProductResponse> GetProductListForSearch(int take, string AppId, string Search)
        {
            ProductResponse res = new ProductResponse();
            try
            {
                var data = await _productRepository.GetProductListForSearch(take, AppId, Search);
                ProductResourceWrapper response = new ProductResourceWrapper
                {
                    ProductList = new List<ProductResource>()
                };
                response.ProductList = data.Select(x => new ProductResource()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Image = EnvironmentConstants.CPImageUrl + x.ProductImages.Where(y => y.IsMain == true).FirstOrDefault().Image,
                    OriginalPrice = x.OriginalPrice,
                    DiscountedPrice = x.DiscountedPrice,
                    DiscountPercentage = x.DiscountPercentage,
                    CategoryName = x.Category.Name,
                    Filters = x.Category.Filters.Select(y => y.Name).ToList(),

                }).ToList();
                res.Message = StringConstants.Message;
                res.data = response;
                return res;
            }
            catch (Exception e)
            {
                res.error = true;
                res.Message = StringConstants.ServerError;
                return res;
            }
        }
        #endregion


        #region GetProductDetail
        public ProductDetailsResponse GetProductDetail(int Id, string AppId)
        {
            ProductDetailsResponse res = new ProductDetailsResponse();
            try
            {
                var product = _productRepository.FindById(Id, AppId);
                if (product == null)
                {
                    res.error = true;
                    res.Message = StringConstants.ProductNotFound;
                    return res;
                }

                ProductDetailsResource pro = new ProductDetailsResource()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    OriginalPrice = product.OriginalPrice,
                    DiscountedPrice = product.DiscountedPrice,
                    DiscountPercent = product.DiscountPercentage,
                    Weight = product.Weight,
                    Dimension = product.Width,
                    MaterialType = product.MaterialType,
                    IncludedAccesories = product.IncludedAccessories,
                    Precautions = product.Precautions,
                    IsAvailable = product.IsAvailable,
                    DeliveryTime = product.DeliveryTime,

                    Images = product.ProductImages.Where(y => y.ProductId == product.Id).Select(y => new ProductImagesResource()
                    {
                        Image = EnvironmentConstants.CPImageUrl + y.Image,
                    }).ToList(),
                    ColorList = product.ProductColors.Where(y => y.ProductId == product.Id).Select(y => new ProductColorsResource()
                    {
                        Id = y.Colors.Id,
                        ColorName = y.Colors.Name,
                        HashCode = y.Colors.HashCode,
                    }).ToList(),
                    SizeList = product.ProductSizes.Where(y => y.ProductId == product.Id).Select(y => new ProductSizeResource()
                    {
                        Id = y.Size.Id,
                        Name = y.Size.ProductSize,
                    }).ToList(),
                };
                res.Message = StringConstants.Message;
                res.data = pro;
                return res;
            }
            catch (Exception e)
            {
                res.error = true;
                res.Message = StringConstants.ServerError;
                return res;
            }
        }
        #endregion

        #region GetAllProductForCategory
        public ProductListResponse GetAllProductForCategory(int CategoryId,  string AppId, int skip, int take)
        {
            ProductListResponse res = new ProductListResponse();
            try
            {
                ProductDetailsResourceWrapper response = new ProductDetailsResourceWrapper
                {
                    ProductList = new List<ProductResource>()
                };
                if (CategoryId == 0)
                {
                    res.error = true;
                    res.Message = StringConstants.CatNotFound;
                    return res;
                }

                else
                {

                    List<Product> ProductRecordsList = _productRepository.GetAllProductForCategory(CategoryId, AppId, skip, take);
                    
                    var ProductRecordsForCount = _productRepository.GetAllProductForCategory(CategoryId, AppId);

                    response.ProductList = ProductRecordsList.Select(x => new ProductResource()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Image = EnvironmentConstants.CPImageUrl + x.ProductImages.Where(y => y.IsMain == true).FirstOrDefault().Image,
                        OriginalPrice = x.OriginalPrice,
                        DiscountedPrice = x.DiscountedPrice,
                        DiscountPercentage = x.DiscountPercentage,
                        IsExclusive = x.IsExclusive,

                    }).ToList();
                    response.TotalCount = ProductRecordsForCount.Count;
                }
                res.Message = StringConstants.Message;
                res.data = response;
                return res;
            }
            catch (Exception e)
            {
                res.error = true;
                res.Message = StringConstants.ServerError;
                return res;
            }
        }
        #endregion

        #region GetAllExclusiveProductForCategory
        public ProductListResponse GetAllExclusiveProductForCategory(int CategoryId, string AppId, int skip, int take)
        {
            ProductListResponse res = new ProductListResponse();
            try
            {
                ProductDetailsResourceWrapper response = new ProductDetailsResourceWrapper
                {
                    ProductList = new List<ProductResource>()
                };
                if (CategoryId == 0)
                {
                    res.error = true;
                    res.Message = StringConstants.CatNotFound;
                    return res;
                }

                else
                {

                    List<Product> ProductRecordsList = _productRepository.GetAllExclusiveProductForCategory(CategoryId, AppId, skip, take);

                    var ProductRecordsForCount = _productRepository.GetAllExclusiveProductForCategory(CategoryId, AppId);

                    response.ProductList = ProductRecordsList.Select(x => new ProductResource()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Image = EnvironmentConstants.CPImageUrl + x.ProductImages.Where(y => y.IsMain == true).FirstOrDefault().Image,
                        OriginalPrice = x.OriginalPrice,
                        DiscountedPrice = x.DiscountedPrice,
                        DiscountPercentage = x.DiscountPercentage,
                        IsExclusive = x.IsExclusive,

                    }).ToList();
                    response.TotalCount = ProductRecordsForCount.Count;
                }
                res.Message = StringConstants.Message;
                res.data = response;
                return res;
            }
            catch (Exception e)
            {
                res.error = true;
                res.Message = StringConstants.ServerError;
                return res;
            }
        }
        #endregion

        #region ApplyAllFilters
        public ProductListResponse ApplyAllFilters(ApplyFiltersResource request)
        {
            ProductListResponse res = new ProductListResponse();
            try
            {
                ProductDetailsResourceWrapper response = new ProductDetailsResourceWrapper
                {
                    ProductList = new List<ProductResource>()
                };
                if (request.CategoryId == 0)
                {
                    res.error = true;
                    res.Message = StringConstants.CatNotFound;
                    return res;
                }

                else
                {

                    List<Product> ProductRecordsList = _productRepository.GetAllProductForCategory(request.CategoryId, request.AppId);

                    List<ProductResource> AllProductList = ProductRecordsList.Select(x => new ProductResource()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        FilterId = x.SubcategoryId,
                        Image = EnvironmentConstants.CPImageUrl + x.ProductImages.Where(y => y.IsMain == true).FirstOrDefault().Image,
                        OriginalPrice = x.OriginalPrice,
                        DiscountedPrice = x.DiscountedPrice,
                        DiscountPercentage = x.DiscountPercentage,
                        IsExclusive = x.IsExclusive,

                    }).ToList();
                    List<ProductResource> FilteredProductList = new List<ProductResource>();
                    foreach (var pro in AllProductList)
                    {
                        foreach (var filter in request.Filters)
                        {
                            if (pro.FilterId == filter)
                                FilteredProductList.Add(pro);
                            
                        }
                    }
                    response.TotalCount = FilteredProductList.Count;
                    response.ProductList = FilteredProductList.Skip(request.skip).Take(request.take).ToList();
                }
                res.Message = StringConstants.Message;
                res.data = response;
                return res;
            }
            catch (Exception e)
            {
                res.error = true;
                res.Message = StringConstants.ServerError;
                return res;
            }
        }
        #endregion

        #region GetRecommendedProduct
        public ProductListResponse GetRecommendedProduct(int CategoryId, int ProductId, string AppId, int skip, int take)
        {
            ProductListResponse res = new ProductListResponse();
            try
            {
                ProductDetailsResourceWrapper response = new ProductDetailsResourceWrapper
                {
                    ProductList = new List<ProductResource>()
                };
                if (CategoryId == 0)
                {
                    res.error = true;
                    res.Message = StringConstants.CatNotFound;
                    return res;
                }

                else
                {

                    var ProductRecordsList = _productRepository.GetAllProductForRecommended(CategoryId, ProductId, AppId, skip, take);

                    var ProductRecordsForCount = _productRepository.GetAllProductForRecommended(CategoryId, ProductId, AppId);

                    response.ProductList = ProductRecordsList.Select(x => new ProductResource()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Image = EnvironmentConstants.CPImageUrl + x.ProductImages.Where(y => y.IsMain == true).FirstOrDefault().Image,
                        OriginalPrice = x.OriginalPrice,
                        DiscountedPrice = x.DiscountedPrice,
                        DiscountPercentage = x.DiscountPercentage,
                        IsExclusive = x.IsExclusive,

                    }).ToList();
                    response.TotalCount = ProductRecordsForCount.Count;
                }
                res.Message = StringConstants.Message;
                res.data = response;
                return res;
            }
            catch (Exception e)
            {
                res.error = true;
                res.Message = StringConstants.ServerError;
                return res;
            }
        }
        #endregion
    }
}
