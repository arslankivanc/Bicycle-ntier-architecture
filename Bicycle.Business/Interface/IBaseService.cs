using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bicycle.Business.Repositories.Interface
{
    public interface IBaseService<T> where T:class
    {
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
        T Find(int id);
        List<T> GetAllRecords();
    }
}
