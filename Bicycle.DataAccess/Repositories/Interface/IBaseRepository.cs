using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bicycle.DataAccess.Repositories.Interface
{
    public interface IBaseRepository<T> where T:class
    {
        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<T> DeleteAsync(T entity);
    }
}
