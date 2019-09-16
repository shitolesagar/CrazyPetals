using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyPetals.Entities.WebViewModels
{
    public class OrderWrapperViewModel
    {
        public List<OrderListViewModel> OrderList { get; set; }
        public PagingData PagingData { get; set; }
        public int TotalCount { get; set; }
    }

    public class OrderListViewModel
    {
        public int Number { get; set; }
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public string Status { get; set; }

    }
}
