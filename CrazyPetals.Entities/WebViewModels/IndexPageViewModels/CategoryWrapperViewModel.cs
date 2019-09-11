using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyPetals.Entities.WebViewModels
{
    public class CategoryWrapperViewModel
    {
        public List<CategoryListViewModel> CategoryList { get; set; }
        public PagingData PagingData { get; set; }
        public int TotalCount { get; set; }
    }

    public class CategoryListViewModel: IdNameViewModel
    {
        public int Number { get; set; }
        public string ImagePath { get; set; }
    }
}
