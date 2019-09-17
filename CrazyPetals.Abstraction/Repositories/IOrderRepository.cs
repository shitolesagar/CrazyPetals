using System.Collections.Generic;
using System.Threading.Tasks;
using CrazyPetals.Entities.Database;
using CrazyPetals.Entities.Filters;

namespace CrazyPetals.Abstraction.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        int GetIndexViewTotalCount(OrderFilter filter);
        Task<List<Order>> GetIndexViewRecordsAsync(OrderFilter filter, int skip, int pageSize);
        Task<Order> GetOrderDetails(int id);
    }
}
