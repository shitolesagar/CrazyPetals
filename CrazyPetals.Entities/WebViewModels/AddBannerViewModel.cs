using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CrazyPetals.Entities.WebViewModels
{
    public class AddBannerViewModel
    {
        [Required(ErrorMessage = "Please enter caption/title.")]
        public string Caption { get; set; }

        [Required(ErrorMessage = "Please select Image.")]
        public string ImageUrl { get; set; }

        public DateTime? ExpireDate { get; set; }

        public IFormFile File { get; set; }
    }
}
