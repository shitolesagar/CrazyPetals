using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyPetals.Entities.Database
{
    public class FullfillmentStatus
    {
        public int Id { get; set; }
        public string Fullfillment_Status { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
