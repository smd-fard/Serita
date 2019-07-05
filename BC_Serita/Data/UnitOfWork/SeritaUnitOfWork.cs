using Serita.Data.Context;
using Common.Data.UnitOfWork;
using Microsoft.Data.Sqlite;
using Serita.Data.UnitOfWork.Interface;

namespace Serita.Data.UnitOfWork
{
    public class SeritaUnitOfWork : BaseUnitOfWork<SeritaContext>, ISeritaUnitOfWork
    {
        public SeritaUnitOfWork(SqliteConnection con)
        {
            dbContext = new SeritaContext(con);
        }

        public SeritaUnitOfWork()
        {
            dbContext = new SeritaContext();
        }
    }
}
