using Common.Domain;
using Microsoft.EntityFrameworkCore;

namespace Common.Data.Repository
{
    //public abstract class BaseReferenceRepository<T> : IUnitOfWork where T : DbContext, new()
    public abstract class BaseReferenceRepository<T> where T : DbContext, new()
    {
        protected T dbContext { get; set; }

        public DbSet<T2> Set<T2>() where T2 : BaseEntity
        {
            return dbContext.Set<T2>();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
