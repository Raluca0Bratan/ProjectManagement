
using ProjectManagement.DataAccess.Model;

namespace ProjectManagement.DataAccess.Abstractions
{
    public interface IBaseRepository<T> where T : ModelEntity
    {
        IEnumerable<T> GetAll();
        T Add(T entity);
        T Update(T entity);
        void Remove(Guid entityId);  
        T GetById(Guid entityId);
    }
}
