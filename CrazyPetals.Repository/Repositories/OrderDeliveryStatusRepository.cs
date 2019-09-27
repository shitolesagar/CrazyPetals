using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Entities.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyPetals.Repository.Repositories
{
    public class OrderDeliveryStatusRepository : Repository<OrderDeliveryStatus>, IOrderDeliveryStatusRepository
    {
        public OrderDeliveryStatusRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
