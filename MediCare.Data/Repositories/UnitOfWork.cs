using DAL.Context;
using DAL.Contracts;
using Domains;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TriCareContext ctx;
        private readonly ConcurrentDictionary<Type, object> repos = new();
        private readonly ILoggerFactory _loggerFactory;
        private IDbContextTransaction _tx;

        public UnitOfWork(TriCareContext context, ILoggerFactory loggerFactory)
        {
            ctx = context;
            _loggerFactory = loggerFactory;
        }

        public IGenericRepository<T> Repository<T>() where T : BaseTable
        {
            return (IGenericRepository<T>)repos.GetOrAdd(
                typeof(T),
                _ => new TableRepository<T>(ctx, _loggerFactory.CreateLogger<TableRepository<T>>()));
        }

        public async Task BeginTransactionAsync()
        {
            if (_tx == null)
            {
                _tx = await ctx.Database.BeginTransactionAsync();
            }
        }

        public async Task CommitAsync()
        {
            if (_tx != null)
            {
                await _tx.CommitAsync();
                await _tx.DisposeAsync();
                _tx = null;
            }
        }

        public async Task RollbackAsync()
        {
            if (_tx != null)
            {
                await _tx.RollbackAsync();
                await _tx.DisposeAsync();
                _tx = null;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await ctx.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            if (_tx != null)
            {
                await _tx.DisposeAsync();
                _tx = null;
            }

            await ctx.DisposeAsync();
        }
    }
}
