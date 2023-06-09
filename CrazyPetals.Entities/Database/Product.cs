﻿using System;
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
        public decimal? OriginalPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public string Description { get; set; }
        public int DiscountPercentage { get; set; }
        public bool IsExclusive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string AppId { get; set; }
        public bool IsAvailable { get; set; }
        public string StockKeepingUnit { get; set; }
        public bool IsDeleted { get; set; }
        public string Width { get; set; }
        public string Length { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string MaterialType { get; set; }
        public string IncludedAccessories { get; set; }
        public string Precautions { get; set; }
        public string DeliveryTime { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        public int? SubcategoryId { get; set; }
        public Subcategory Subcategory { get; set; }

        public ICollection<ProductImages> ProductImages { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public ICollection<CartDetails> CartDetails { get; set; }
        public ICollection<ProductColor> ProductColors { get; set; }
        public ICollection<ProductSize> ProductSizes { get; set; }
    }
}
