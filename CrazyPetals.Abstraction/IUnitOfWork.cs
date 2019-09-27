using System;
using System.Threading;
using System.Threading.Tasks;

namespace CrazyPetals.Abstraction
{
    public interface IUnitOfWork : IDisposable
    {
        #region Methods
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        #endregion
    }
}
