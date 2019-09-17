using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrazyPetals.Entities.Database
{
    public class Order
    {
        public int Id { get; set; }

        public decimal SubTotalPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public decimal TotalPrice { get; set; }

        public decimal GSTPrice { get; set; }
        public decimal DeliveryCharges { get; set; }

        public string OrderNumber { get; set; }

        public DateTime CreatedDate { get; set; }

        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int UserAddressId { get; set; }
        public UserAddress UserAddress { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }
        public int MRP { get; set; }

        public int PaymentStatusId { get; set; }
        public OrderPaymentStatus PaymentStatus { get; set; }

        public int DeliveryStatusId { get; set; }
        public OrderDeliveryStatus DeliveryStatus { get; set; }
    }
}
