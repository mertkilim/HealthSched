using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HealthSched.DAL.Repositories.Abstract
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int? id);
        Task<IEnumerable<T>> GetByFilterAsync(Expression<Func<T, bool>>? predicate);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<T> GetAsync(Expression<Func<T, bool>> filter, string? includeProperties = null);
        Task<IEnumerable<T>> GetAllAsync(string? includeProperties = null);
        Task<IEnumerable<T>> GetAllByFilter(Expression<Func<T, bool>>? predicate = null, string? includeProperties = null);
    }
}
