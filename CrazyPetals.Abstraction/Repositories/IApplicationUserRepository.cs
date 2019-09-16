using CrazyPetals.Entities.Database;
using CrazyPetals.Entities.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrazyPetals.Abstraction.Repositories
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        ApplicationUser FindByEmail(string Email);
        int GetCustomerIndexViewTotalCount(FilterBase filter);
        Task<List<ApplicationUser>> GetCusotmerIndexViewRecordsAsync(FilterBase filter, int skip, int pageSize);
    }
}
