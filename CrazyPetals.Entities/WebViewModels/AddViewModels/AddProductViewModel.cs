using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CrazyPetals.Entities.WebViewModels
{
    public class AddProductViewModel
    {
        [Required(ErrorMessage = "Product name is required")]
        public string ProductName { get; set; }

        public int? CategoryId { get; set; }
        public int? SubcategoryId { get; set; }

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Original Price is not valid.")]
        public int? OriginalPrice { get; set; }

        [Required(ErrorMessage = "Offer price is required.")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Offer Price is not valid.")]
        public int DiscountedPrice { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string LongDescription { get; set; }

        [Required(ErrorMessage = "Unit is required.")]
        public int? UnitId { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Quantity is not valid.")]
        public string Quantity { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; }

        public IFormFile Image { get; set; }
        [Required(ErrorMessage = "Main image is required.")]
        public string MainImageText { get; set; }

        public IFormFile Image1 { get; set; }
        public IFormFile Image2 { get; set; }
        public IFormFile Image3 { get; set; }
        public IFormFile Image4 { get; set; }

        public string StockKeepingUnit { get; set; }
        public string Brand { get; set; }


        public List<int> Ids { get; set; }
    }
}
