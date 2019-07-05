using Common.Data.Repository.Interface;
using Shared.Domain.Local;

namespace Shared.Data.Repository.Interface
{
    public interface IStatusRep : IRepository<Status>
    {
        Status Find(int id, int languageId);
    }
}
