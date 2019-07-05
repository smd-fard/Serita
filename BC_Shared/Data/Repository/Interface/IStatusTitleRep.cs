using Common.Data.Repository.Interface;
using Shared.Domain.Local;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Data.Repository.Interface
{
    public interface IStatusTitleRep : IRepository<StatusTitle>
    {
        StatusTitle Find(int id, int languageId);
    }
}
