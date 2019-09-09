using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Entities.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrazyPetals.Repository.Repositories
{
    public class CartDetailsRepository : Repository<CartDetails>, ICartDetailsRepository
    {
        public CartDetailsRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<CartDetails> FindByApplicationUserId(int ApplicationUserId)
        {

            return Set.Where(x => x.ApplicationUserId == ApplicationUserId).ToList();
        }

        public CartDetails FindByProductDetailId(int ProductId, string AppId, int ApplicationUserId)
        {
            return Set.Where(x => x.ProductId == ProductId && x.AppId == AppId && x.ApplicationUserId == ApplicationUserId).FirstOrDefault();
        }

        public Task<List<CartDetails>> GetAllItemsForUser(string AppId, int ApplicationUserId)
        {

            return Set.Where(x => x.ApplicationUserId == ApplicationUserId && x.AppId == AppId).ToListAsync();
        }

        public CartDetails FindByProductsDetailId(int ProductId, string AppId, int ApplicationUserId)
        {
            return Set.Where(x => x.ProductId == ProductId && x.AppId == AppId && x.ApplicationUserId == ApplicationUserId).FirstOrDefault();
        }
    }
}
