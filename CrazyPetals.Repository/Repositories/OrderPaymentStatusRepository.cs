using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Entities.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyPetals.Repository.Repositories
{
    public class OrderPaymentStatusRepository : Repository<OrderPaymentStatus>, IOrderPaymentStatusRepository
    {
        public OrderPaymentStatusRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
