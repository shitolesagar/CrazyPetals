using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CrazyPetals.Entities.WebViewModels
{
    public class AddFilterViewModel
    {
        [Required(ErrorMessage= "Please select category.")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Please enter Filter name.")]
        public string FilterName { get; set; }
    }
}
