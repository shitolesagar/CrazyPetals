﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CrazyPetals.Entities.WebViewModels
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }
        public string MainImageUrl { get; set; }
        public List<string> ImagesPaths { get; set; } = new List<string>();
        public string ProductName { get; set; }
        public string LongDescription { get; set; }
        public string CategoryName { get; set; }
        public string FilterName { get; set; }
        public string Status { get; set; }
        public string OriginalPrice { get; set; }
        public string DiscountedPrice { get; set; }
        public string ProductLength { get; set; }
        public string ProductWidth { get; set; }
        public string ProductHeight { get; set; }
        public string ProductWeight { get; set; }
        public string MaterialType { get; set; }
        public string Accessories { get; set; }
        public string PrecautionsInstructions { get; set; }
        public string DeliveryTime { get; set; }
        public string StockKeepingUnit { get; set; }
        public string IsExclusive { get; set; }
        public string IsAvailable { get; set; }
        public string AvailableSizes { get; set; }
        public string AvailableColors { get; set; }
        public string AddedOn { get; set; }
    }
}
