using Common.Data.Repository;
using Common.Data.UnitOfWork.Interface;
using Shared.Data.UnitOfWork;
using Shared.Data.Repository.Interface;
using Shared.Domain.Local;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shared.Data.Repository
{
    public class StatusRep : BaseRepository<Status>, IStatusRep
    {
        public StatusRep(IUnitOfWork uow) : base(uow)
        {
        }

        public Status Find(int id, int languageId)
        {
            return _dbSet.AsNoTracking().FirstOrDefault(x => x.Id == id && x.LanguageId == languageId);
        }
    }
}
