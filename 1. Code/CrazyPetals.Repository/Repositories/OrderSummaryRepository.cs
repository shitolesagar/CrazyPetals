using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Entities.Database;

namespace CrazyPetals.Repository.Repositories
{
    public class OrderSummaryRepository : Repository<OrderSummary>, IOrderSummaryRepository
    {
        public OrderSummaryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
