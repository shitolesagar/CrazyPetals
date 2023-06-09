﻿using CrazyPetals.Entities.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrazyPetals.Abstraction.Repositories
{
    public interface ICartDetailsRepository : IRepository<CartDetails>
    {
        List<CartDetails> FindByApplicationUserId(int ApplicationUserId);

        CartDetails FindByProductDetailId(int ProductId, string AppId, int ApplicationUserId);

        Task<List<CartDetails>> GetAllItemsForUser(string AppId, int ApplicationUserId);

        CartDetails FindByProductsDetailId(int ProductId, string AppId, int ApplicationUserId);
    }
}
