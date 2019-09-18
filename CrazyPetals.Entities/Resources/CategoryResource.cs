using CrazyPetals.Entities.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyPetals.Entities.Resources
{
    public class AppThemeResponse
    {
        public string PrimaryColor { get; set; }
        public string SecondryColor { get; set; }
        public string StatusBarColor { get; set; }
        public string TextColor { get; set; }
        public string CurrencySymbol { get; set; }
        public string AppName { get; set; }
        public string AppLogoURL { get; set; }
    }

    public class ApplicationThemeResponse
    {
        public bool error { get; set; } = false;
        public string Message { get; set; }
        public AppThemeResponse data { get; set; }
    }

    public class VersionResponse
    {
        public bool error { get; set; } = false;
        public string Message { get; set; }
        public VersionControl data { get; set; }
    }

    public class BannerResource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }

    }

    public class BannerResourceWrapper
    {
        public List<BannerResource> BannerList { get; set; }
    }
    public class BannerResponse
    {
        public bool error { get; set; } = false;
        public string Message { get; set; }
        public BannerResourceWrapper data { get; set; }
    }

    public class CategoryResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

    }

    public class CategoryResourceWrapper
    {
        public List<CategoryResource> CategoryList { get; set; }
    }
    public class CategoryResponse
    {
        public bool error { get; set; } = false;
        public string Message { get; set; }
        public CategoryResourceWrapper data { get; set; }
    }

    public class NotificationResource
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }

    }

    public class NotificationResourceWrapper
    {
        public List<NotificationResource> NotificationList { get; set; }
    }
    public class NotificationResponse
    {
        public bool error { get; set; } = false;
        public string Message { get; set; }
        public NotificationResourceWrapper data { get; set; }
    }


    public class FilterResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class FilterResourceWrapper
    {
        public List<FilterResource> FilterList { get; set; }
    }

    public class FilterResponse
    {
        public bool error { get; set; } = false;
        public string Message { get; set; }
        public FilterResourceWrapper data { get; set; }
    }

    public class ProductListRequestResource
    {
        public string AppId { get; set; }
        public int take { get; set; }
        public int CategoryId { get; set; }
        public ICollection<int> filters { get; set; }
        public bool ShowOnlyExclusive { get; set; }
    }
    public class ProductResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal? OriginalPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public int DiscountPercentage { get; set; }
        public string CategoryName { get; set; }
        public bool IsExclusive { get; set; }
        public ICollection<string> Filters { get; set; }
    }
    public class ProductResourceWrapper
    {
        public List<ProductResource> ProductList { get; set; }
    }

    public class ProductResponse
    {
        public bool error { get; set; } = false;
        public string Message { get; set; }
        public ProductResourceWrapper data { get; set; }
    }

    public class ProductDetailsResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? OriginalPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public int DiscountPercent { get; set; }
        public string Weight { get; set; }
        public string Dimension { get; set; }
        public string MaterialType { get; set; }
        public string IncludedAccesories { get; set; }
        public string Precautions { get; set; }
        public ICollection<ProductImagesResource> Images { get; set; }
        public ICollection<ProductColorsResource> ColorList { get; set; }
        public ICollection<ProductSizeResource> SizeList { get; set; }
    }
    public class ProductDetailsResourceWrapper
    {
        public List<ProductResource> ProductList { get; set; }
        public int TotalCount { get; set; }
    }
    public class ProductListResponse
    {
        public bool error { get; set; }
        public string Message { get; set; }
        public ProductDetailsResourceWrapper data { get; set; }
    }
    public class ProductImagesResource
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public bool IsMaIN { get; set; }
    }
    public class ProductColorsResource
    {
        public int Id { get; set; }
        public string ColorName { get; set; }
        public string HashCode { get; set; }
    }
    public class ProductSizeResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ProductDetailsResponse
    {
        public bool error { get; set; } = false;
        public string Message { get; set; }
        public ProductDetailsResource data { get; set; }
    }
}
