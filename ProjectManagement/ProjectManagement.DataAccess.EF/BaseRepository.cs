

using Microsoft.EntityFrameworkCore;
using ProjectManagement.DataAccess.Abstractions;
using ProjectManagement.DataAccess.Model;

namespace ProjectManagement.DataAccess.EF
{
    public class BaseRepository<T> : IBaseRepository<T> where T : ModelEntity
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

        public void Remove(Guid entityId)
        {
            var element = context.Set<T>().First(e => e.Id == entityId);
            context.Remove(element);
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

        public T GetById(Guid id)
        {
            return context.Set<T>().FirstOrDefault(t => t.Id == id);
        }

    }
}
