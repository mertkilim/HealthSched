using HealthSched.BL.Abstract;
using HealthSched.DAL.Repositories.Concrete;
using HealthSched.Models.Models.Abstract;
using HealthSched.Models.Models.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HealthSched.BL.Concrete
{
    public class Service<T> : IService<T>
        where T : BaseEntity
    {
        private readonly Repository<T> _repository;
        public Service(Repository<T> repository)
        {
            _repository = repository;
        }
        public virtual async Task<T> CreateAsync(T entity)
        {
            return await _repository.AddAsync(entity);
            
        }

        public virtual async Task<T> DeleteAsync(T entity)
        {
            return await _repository.DeleteAsync(entity);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(string? includeProperties = null)
        {
            return await _repository.GetAllAsync(includeProperties);
        }

        public virtual async Task<IEnumerable<T>> GetAllIncludeAsync(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[]? include)
        {
            return await _repository.GetAllByFilter(predicate);
        }

        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _repository.GetAsync(predicate);
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            return await _repository.UpdateAsync(entity);
        }
    }
}
