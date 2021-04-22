using Bicycle.Business.Repositories.Interface;
using Bicycle.DataAccess.Contexts;
using Bicycle.DataAccess.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bicycle.Business.Repositories.Concrete
{
    public class BaseService<T> :IDisposable, IBaseService<T> where T : class
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseService(DatabaseContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public T Add(T entity)
        {
            _dbSet.AddAsync(entity);
            _context.SaveChanges();
            return entity;
        }

        public  T Delete(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public T Find(int id)
        {
            var data= _dbSet.Find(id);
            return data;
        }

        public List<T> GetAllRecords()
        {
            return  _dbSet.ToList();
        }

        public T Update(T entity)
        {
            _dbSet.Update(entity);
             _context.SaveChanges();
            return entity;
        }
    }
}
