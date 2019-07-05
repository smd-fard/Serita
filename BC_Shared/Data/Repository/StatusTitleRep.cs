using Common.Data.Repository;
using Common.Data.UnitOfWork.Interface;
using Shared.Data.UnitOfWork;
using Shared.Data.Repository.Interface;
using Shared.Domain.Local;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Shared.Data.Repository
{
    public class StatusTitleRep : BaseRepository<StatusTitle>, IStatusTitleRep
    {
        public StatusTitleRep(IUnitOfWork uow) : base(uow)
        {
        }

        public StatusTitle Find(int id, int languageId)
        {
            return _dbSet.AsNoTracking().FirstOrDefault(x => x.Id == id && x.LanguageId == languageId);
        }
    }
}
