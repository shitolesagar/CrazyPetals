using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Entities.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CrazyPetals.Repository.Repositories
{
    public class ForgotPasswordRepository : Repository<ForgotPassword>, IForgotPasswordRepository
    {
        public ForgotPasswordRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ForgotPassword FindByEmailOtp(string Email, string OTP)
        {
            return Set.Include(x => x.ApplicationUser).LastOrDefault(x=>x.ExpireDate > DateTime.Now && x.ApplicationUser.Email == Email);
        }
    }
}
