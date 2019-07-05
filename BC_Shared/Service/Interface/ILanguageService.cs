using Shared.Domain.Local;
using System.Collections.Generic;

namespace Shared.Service.Interface
{
    public interface ILanguageService
    {
        Language Find(int id);
        IEnumerable<Language> GetAll();
    }
}
