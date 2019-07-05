using Common.Domain;

namespace Common.Data.Repository.Interface
{
    public interface IRepositoryTitle<T> : IBase<T> where T : BaseLookupTitle
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id, int languageId);
        T Find(int id, int languageId);
    }
}
