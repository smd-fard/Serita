using Common.Domain;

namespace Common.Data.Repository.Interface
{
    public interface IRepositoryLookupView<T> : IBase<T> where T : BaseEntity
    {
        T Find(int id, int languageId);
    }
}
