using Common.Domain;

namespace Common.Data.Repository.Interface
{
    public interface IRepositoryView<T> : IBase<T> where T : BaseEntity
    {
        T Find(int id);
    }
}
