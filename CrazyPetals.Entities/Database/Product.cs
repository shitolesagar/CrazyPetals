using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrazyPetals.Entities.Database
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPublish { get; set; }
        public int OriginalPrice { get; set; }
        public int DiscountedPrice { get; set; }
        public string Description { get; set; }
        public int DiscountPercentage { get; set; }
        public bool IsExclusive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string AppId { get; set; }
        public bool IsAvailable { get; set; }
        public int StockKeepingUnit { get; set; }
        public string Size { get; set; }
        public bool IsDeleted { get; set; }
        public string Dimension { get; set; }
        public string Weight { get; set; }
        public string MaterialType { get; set; }
        public string IncludedAccessories { get; set; }
        public string Precautions { get; set; }
        public string DeliveryTime { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int? FilterId { get; set; }
        public Filter Filter { get; set; }

        public ICollection<ProductImages> ProductImages { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public ICollection<CartDetails> CartDetails { get; set; }
        //public ICollection<FilterProduct> FilterProducts { get; set; }
        public ICollection<ProductColor> ProductColors { get; set; }
        public ICollection<ProductSize> ProductSizes { get; set; }
    }
}
