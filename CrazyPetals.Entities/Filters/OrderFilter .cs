using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyPetals.Entities.Filters
{
    public class OrderFilter: FilterBase
    {
        public int StatusId { get; set; }
    }

    public class UpdateStatusResource
    {
        public int Id { get; set; }
        public int DeliveryStatusId { get; set; }
    }
}
