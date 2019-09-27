using CrazyPetals.Entities.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyPetals.Abstraction.Repositories
{
    public interface IDelivery_chargeRepository : IRepository<DeliveryCharge>
    {
        DeliveryCharge findByMin(int min, string AppId);
    }
}
