using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyPetals.Entities.Database
{
    public class PaymentStatus
    {
        public int Id { get; set; }
        public string Payment_Status { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
