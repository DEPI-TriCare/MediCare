using MediCare.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCare.Data.Repositories
{
    public class GenericRepository<T, TKey> : IGenericRepository <T, TKey>
        where T : class
    {
        protected AppDbContext _context;
        public GenericRepository(AppDbContext context) { 
            _context = context;
        }
        public async Task<T> Add(T entity)
        {
            var entry = await _context.Set<T>().AddAsync(entity);
            return entry.Entity;
        }

        public async Task Delete(TKey id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity is null)
                throw new KeyNotFoundException($"Entity with type: {typeof(T)} and id: {id} not found.");
            
            _context.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public async Task<T?> GetById(TKey id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            return entity; 
        }

        public async Task<T?> Update(T entity)
        {
            return _context.Set<T>().Update(entity).Entity;
        }
    }
}
