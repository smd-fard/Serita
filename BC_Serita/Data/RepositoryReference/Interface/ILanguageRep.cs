using Serita.Domain.Reference;
using System;
using System.Collections.Generic;
using System.Text;

namespace Serita.Data.RepositoryReference.Interface
{
    public interface ILanguageRep
    {
        Language Find(int id);
        ICollection<Language> GetAll();
    }
}
