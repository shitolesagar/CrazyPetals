using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrazyPetals.Entities.Database
{
    public class OrderSummary
    {
        public int Id { get; set; }
        public int MRP { get; set; }
        public int Discount { get; set; }
        public int GST { get; set; }
        public int DeliveryCharges { get; set; }
        public int SubTotal { get; set; }
        public DateTime CreatedDate { get; set; }
        public string AppId { get; set; }

        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int UserAddressId { get; set; }
        public UserAddress UserAddress { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
