using Shared.Domain.Local;
using System.Collections.Generic;

namespace Shared.Service.Interface
{
    public interface IStatusService
    {
        Status Find(int id, int languageId);
        IEnumerable<Status> GetAll(int languageId);
    }
}
