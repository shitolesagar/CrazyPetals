using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Entities.Database;
using CrazyPetals.Entities.Filters;
using Microsoft.EntityFrameworkCore;

namespace CrazyPetals.Repository.Repositories
{
    public class OrderSummaryRepository : Repository<OrderSummary>, IOrderSummaryRepository
    {
        public OrderSummaryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<List<OrderSummary>> GetIndexViewRecordsAsync(OrderFilter filter, int skip, int pageSize)
        {
            return Set.Skip(skip).Take(pageSize).ToListAsync();
        }

        public int GetIndexViewTotalCount(OrderFilter filter)
        {
            return Set.Count();
        }
    }
}
