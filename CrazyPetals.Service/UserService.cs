using CrazyPetals.Abstraction.Service;
using CrazyPetals.Entities.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrazyPetals.Service
{
    public class UserService : IUserService
    {
        public Task<ApplicationUser> GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
