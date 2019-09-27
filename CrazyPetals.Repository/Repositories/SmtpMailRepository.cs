using CrazyPetals.Abstraction.Repositories;
using CrazyPetals.Entities.Database;

namespace CrazyPetals.Repository.Repositories
{
    public class SmtpMailRepository : Repository<SmtpMail>, ISmtpMailRepository
    {
        public SmtpMailRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
