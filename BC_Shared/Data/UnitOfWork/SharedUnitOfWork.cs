using Common.Data.UnitOfWork;
using Microsoft.Data.Sqlite;
using Shared.Data.Context;
using Shared.Data.UnitOfWork.Interface;

namespace Shared.Data.UnitOfWork
{
    public class SharedUnitOfWork : BaseUnitOfWork<SharedContext>, ISharedUnitOfWork
    {
        public SharedUnitOfWork(SqliteConnection con)
        {
            dbContext = new SharedContext(con);
        }

        public SharedUnitOfWork()
        {
            dbContext = new SharedContext();
        }
    }
}
