using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IQueryable<T> Set();
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
