using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyPetals.Entities.Database
{
    public class OrderDeliveryStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
