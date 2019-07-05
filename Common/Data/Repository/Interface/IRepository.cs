using Common.Domain;

namespace Common.Data.Repository.Interface
{
    public interface IRepository<T> : IBase<T> where T : BaseEntity
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        T Find(int id);
    }
}
