using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CrazyPetals.Entities.WebViewModels
{
    public class AddCategoryViewModel
    {
        [Required(ErrorMessage= "Please enter category name.")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage ="Please select Image.")]
        public string ImageUrl { get; set; }

        public IFormFile File { get; set; }
    }
}
