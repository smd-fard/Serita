using Common.Data.Repository;
using Common.Data.UnitOfWork.Interface;
using Shared.Data.UnitOfWork;
using Shared.Data.Repository.Interface;
using Shared.Domain.Local;

namespace Shared.Data.Repository
{
    public class StatusValueRep : BaseRepository<StatusValue>, IStatusValueRep
    {
        public StatusValueRep(IUnitOfWork uow) : base(uow)
        {
        }
    }
}
