using Shared.Data.Repository.Interface;
using Shared.Data.UnitOfWork;
using Shared.Data.UnitOfWork.Interface;
using Shared.Domain.Local;
using Shared.Service.Interface;
using System.Collections.Generic;

namespace Shared.Service
{
    public class LanguageService : ILanguageService
    {
        ISharedUnitOfWork _uow;
        ILanguageRep _rep;

        public LanguageService(ISharedUnitOfWork uow, ILanguageRep rep)
        {
            _uow = uow;
            _rep = rep;
        }
        
        public IEnumerable<Language> GetAll()
        {
            return _rep.Get();
        }

        public Language Find(int id)
        {
            return _rep.Find(id);
        }
    }
}
