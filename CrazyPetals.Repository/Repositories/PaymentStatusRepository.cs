using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Entities.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyPetals.Repository.Repositories
{
    public class PaymentStatusRepository : Repository<PaymentStatus>, IPaymentStatusRepository
    {
        public PaymentStatusRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
