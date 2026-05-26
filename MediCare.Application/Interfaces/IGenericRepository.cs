using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCare.Application.Interfaces
{
    public interface IGenericRepository<T, TKey>
    {
        public Task<T?> GetById(TKey id);
        public Task<T> Add(T entity);
        public Task Update(T entity);
        public Task Delete(TKey id);
        public IQueryable<T> GetAll();
    }
}
