using Common.Data.Repository;
using Common.Data.UnitOfWork.Interface;
using Shared.Data.Repository.Interface;
using Shared.Data.UnitOfWork;
using Shared.Domain.Local;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Data.Repository
{
    public class LanguageRep : BaseRepository<Language>, ILanguageRep
    {
        public LanguageRep(IUnitOfWork uow) : base(uow)
        {
        }
    }
}
