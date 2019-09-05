using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrazyPetals.Entities.Database
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int DiscountedPrice { get; set; }
        public int OriginalPrice { get; set; }
        public string AppId { get; set; }

        public int OrderSummaryId { get; set; }
        public OrderSummary OrderSummary { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
