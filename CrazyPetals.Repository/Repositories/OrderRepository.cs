using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Entities.Database;
using CrazyPetals.Entities.Filters;
using Microsoft.EntityFrameworkCore;

namespace CrazyPetals.Repository.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<List<Order>> GetIndexViewRecordsAsync(OrderFilter filter, int skip, int pageSize)
        {
            var query = Set.Include(x => x.DeliveryStatus).Include(x => x.ApplicationUser).AsQueryable();
            if (!string.IsNullOrEmpty(filter.search))
            {
                query = query.Where(x => x.OrderNumber.ToLower().Contains(filter.search.ToLower()) );
            }
            if (filter.StatusId != 0)
            {
                query = query.Where(x => x.PaymentStatus.Id == filter.StatusId).OrderByDescending(x => x.Id);
            }
            return query.OrderByDescending(x => x.CreatedDate).Skip(skip).Take(pageSize).ToListAsync();
        }

        public int GetIndexViewTotalCount(OrderFilter filter)
        {
            var query = Set.Include(x => x.DeliveryStatus).AsQueryable();
            if (!string.IsNullOrEmpty(filter.search))
            {
                query = query.Where(x => x.OrderNumber.ToLower().Contains(filter.search.ToLower()));
            }
            if (filter.StatusId != 0)
            {
                query = query.Where(x => x.PaymentStatus.Id == filter.StatusId).OrderByDescending(x => x.Id);
            }
            return query.Count();
        }
        public Task<Order> GetOrderDetails(int id)
        {
            return Set.Include(x => x.ApplicationUser).ThenInclude(y=>y.UserAddresses) .Include(x => x.DeliveryStatus).Include(x => x.PaymentStatus).Include(x=>x.OrderDetails).ThenInclude(y=>y.Product).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
