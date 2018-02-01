using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly Context context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(Context context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public IQueryable<T> Set()
        {
            return context.Set<T>();
        }
    }
}
