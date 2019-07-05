using Shared.Data.Repository.Interface;
using Shared.Data.UnitOfWork;
using Shared.Data.UnitOfWork.Interface;
using Shared.Domain.Local;
using Shared.Service.Interface;
using System.Collections.Generic;

namespace Shared.Service
{
    public class StatusService : IStatusService
    {
        ISharedUnitOfWork _uow;
        IStatusRep _rep;

        public StatusService(ISharedUnitOfWork uow, IStatusRep rep)
        {
            _uow = uow;
            _rep = rep;
        }

        public Status Find(int id, int languageId)
        {
            return _rep.Find(id, languageId);
        }

        public IEnumerable<Status> GetAll(int languageId)
        {
            return _rep.Get(x => x.LanguageId == languageId);
        }
    }
}
