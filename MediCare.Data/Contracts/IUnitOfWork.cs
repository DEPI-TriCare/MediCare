using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        public IGenericRepository<T> Repository<T>() where T : BaseTable;
        public Task BeginTransactionAsync();
        public Task CommitAsync();
        public Task RollbackAsync();
        public Task<int> SaveChangesAsync();
    }
}
