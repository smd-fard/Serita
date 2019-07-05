using Common.Data.UnitOfWork.Interface;
using Common.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Common.Data.UnitOfWork
{
    public abstract class BaseUnitOfWork<T> : IUnitOfWork where T : DbContext, new()
    {
        protected T dbContext { get; set; }

        public int Commit()
        {
            return dbContext.SaveChanges();
        }

        public DbSet<T2> Set<T2>() where T2 : BaseEntity
        {
            return dbContext.Set<T2>();
        }

        public EntityEntry<T2> Entry<T2>(T2 entity) where T2 : BaseEntity
        {
            return dbContext.Entry<T2>(entity);
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
    /*
     public abstract class BaseUnitOfWork<T> : IUnitOfWork where T : DbContext, new()
    {
        protected T dbContext { get; set; }

        public int Save()
        {
            return dbContext.SaveChanges();
        }

        public DbSet<T2> Set<T2>() where T2 : BaseEntity
        {
            return dbContext.Set<T2>();
        }

        public EntityEntry<T2> Entry<T2>(T2 entity) where T2 : BaseEntity
        {
            return dbContext.Entry<T2>(entity);
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
    */
}
