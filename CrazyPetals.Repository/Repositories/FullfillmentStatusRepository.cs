using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Entities.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrazyPetals.Repository.Repositories
{
    public class FullfillmentStatusRepository : Repository<FullfillmentStatus>, IFullfillmentStatusRepository
    {
        public FullfillmentStatusRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
