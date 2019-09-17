using CrazyPetals.Entities.Database;
using System.Collections.Generic;

namespace CrazyPetals.Abstraction.Repositories
{
    public interface IOrderDetailsRepository : IRepository<OrderDetails>
    {
        List<OrderDetails> GetAllItemsForOrder(int id);
    }
}
