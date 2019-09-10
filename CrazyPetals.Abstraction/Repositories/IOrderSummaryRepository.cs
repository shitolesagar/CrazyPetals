using System.Collections.Generic;
using System.Threading.Tasks;
using CrazyPetals.Entities.Database;
using CrazyPetals.Entities.Filters;

namespace CrazyPetals.Abstraction.Repositories
{
    public interface IOrderSummaryRepository : IRepository<OrderSummary>
    {
        int GetIndexViewTotalCount(OrderFilter filter);
        Task<List<OrderSummary>> GetIndexViewRecordsAsync(OrderFilter filter, int skip, int pageSize);
    }
}
