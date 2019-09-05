using CrazyPetals.Entities.Database;
using System.Threading.Tasks;

namespace CrazyPetals.Abstraction.Service
{
    public interface IUserService
    {
        Task<ApplicationUser> GetUserByEmail(string email);
    }
}