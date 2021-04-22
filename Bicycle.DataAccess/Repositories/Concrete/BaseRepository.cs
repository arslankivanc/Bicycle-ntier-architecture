using Bicycle.DataAccess.Contexts;
using Bicycle.DataAccess.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bicycle.DataAccess.Repositories.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            var addedData = (await _dbSet.AddAsync(entity)).Entity;
            await _context.SaveChangesAsync();

            return addedData;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            var removedData = _dbSet.Remove(entity).Entity;
            await _context.SaveChangesAsync();

            return removedData;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
