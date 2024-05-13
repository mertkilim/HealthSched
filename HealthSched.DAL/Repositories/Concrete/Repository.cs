using HealthSched.DAL.DbContexts.SqlServer;
using HealthSched.DAL.Repositories.Abstract;
using HealthSched.Models.Models.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HealthSched.DAL.Repositories.Concrete
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly SqlServerDbContext _context;
        internal DbSet<T> _dbSet;

        public Repository(SqlServerDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            entity.isDeleted = true;
            _dbSet.Update(entity);
            return entity;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            query = query.Where(filter);
            if(!string.IsNullOrEmpty(includeProperties))
            {
                foreach(var includeProperty in includeProperties
                    .Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries)) 
                {
                    query = query.Include(includeProperty);
                }
            }
            return query.FirstOrDefault();
        }

        public async Task<IEnumerable<T>> GetAllAsync(string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;
            if(!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties
                    .Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return query.ToList();
        }

        public async Task<IEnumerable<T>> GetAllByFilter(Expression<Func<T, bool>>? predicate = null, string? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;

            if(predicate != null)
            {
                query= query.Where(predicate);
            }

            if(!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties
                    .Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<IQueryable<T>> GetByFilter(Expression<Func<T, bool>>? predicate)
        {
            IQueryable<T> query = _dbSet;
            query.Where(predicate);
            return query;
        }

        public async Task<T> GetByIdAsync(int? id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return entity;
        }
    }
}
