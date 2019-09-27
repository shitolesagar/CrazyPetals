using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CrazyPetals.Entities.WebViewModels
{
    public class AddSubcategoryViewModel
    {
        [Required(ErrorMessage= "Please select category.")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Please enter subcategory name.")]
        public string SubcategoryName { get; set; }
    }
}
