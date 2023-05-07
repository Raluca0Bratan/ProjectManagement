

using System.Linq.Expressions;

namespace ProjectManagement.DataAccess.Abstractions
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Add(T entity);
        T Update(T entity);
        void Remove(T entity);
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
       
    }
}
