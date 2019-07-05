using Serita.Data.RepositoryReference.Interface;
using System;
using System.Collections.Generic;
using Serita.Domain.Reference;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Common.Data.Repository;
using Microsoft.Data.Sqlite;
using Serita.Data.Context;

namespace Serita.Data.RepositoryReference
{
    public class LanguageRep : BaseReferenceRepository<SeritaContext>, ILanguageRep, IDisposable
    {
        protected readonly DbSet<Language> _dbSet;

        public LanguageRep()
        {
            dbContext = new SeritaContext();
            _dbSet = base.Set<Language>();
        }

        public LanguageRep(SqliteConnection con)
        {
            dbContext = new SeritaContext(con);
            _dbSet = base.Set<Language>();
        }

        public Language Find(int id)
        {
            return _dbSet.AsNoTracking<Language>().FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Language> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }
    }
    /*
        public class LanguageRep : ILanguageRep, IDisposable
    {
        protected IUnitOfWork _uow { get; set; }
        protected readonly DbSet<Language> _dbSet;

        public LanguageRep(IUnitOfWork uow)
        {
            _uow = uow;
            _dbSet = uow.Set<Language>();
        }

        public ICollection<Language> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public void Dispose()
        {
            _uow.Dispose();
        } 
    }
    */
}
