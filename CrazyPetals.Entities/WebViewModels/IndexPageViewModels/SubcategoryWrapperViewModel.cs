using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyPetals.Entities.WebViewModels
{
    public class FilterWrapperViewModel
    {
        public List<FilterListViewModel> SubcateogryList { get; set; }
        public PagingData PagingData { get; set; }
        public int TotalCount { get; set; }
    }

    public class FilterListViewModel
    {
        public int Number { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
    }
}
