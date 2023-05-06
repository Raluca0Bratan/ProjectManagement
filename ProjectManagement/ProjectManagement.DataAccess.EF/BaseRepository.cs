

using Microsoft.EntityFrameworkCore;
using ProjectManagement.DataAccess.Abstractions;
using ProjectManagement.DataAccess.Model;
using System.Linq.Expressions;

namespace ProjectManagement.DataAccess.EF
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbContext context;
        public BaseRepository(DbContext context)
        {
            this.context = context;
        }
        public T Add(T entity)
        {
            var added = context.Set<T>().Add(entity);
            context.SaveChanges();
            return added.Entity;
        }

        public void Remove(T entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T Update(T toUpdate)
        {
            var updated = context.Set<T>().Update(toUpdate);
            context.SaveChanges();
            return updated.Entity;
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.context.Set<T>().Where(expression).AsNoTracking();
        }

    }
}
