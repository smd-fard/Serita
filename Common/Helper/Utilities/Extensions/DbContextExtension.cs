using Common.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Common.Helper.Utilities.Extensions
{
    public static class DbContextExtension
    {
        public static void FixDate(this DbContext dbContext)
        {
            foreach (var entry in dbContext.ChangeTracker.Entries<BaseDomain>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        {
                            DateTimeOffset utcNow = DateTimeOffset.UtcNow;
                            entry.Entity.CreateDate = utcNow;
                            entry.Entity.ModifyDate = utcNow;
                            break;
                        }
                    case EntityState.Modified:
                        {
                            entry.Entity.ModifyDate = DateTimeOffset.UtcNow;
                            break;
                        }
                }
            }
        }

        //public static void FixState(this DbContext dbContext)
        //{
        //    foreach (var entry in dbContext.ChangeTracker.Entries<BaseEntity>())
        //    {
        //        entry.State = ToEntityState(entry.Entity.State);
        //    }
        //}

        //private static EntityState ToEntityState(ObjectState objectState)
        //{
        //    switch (objectState)
        //    {
        //         case ObjectState.Added:
        //            {
        //                return EntityState.Added;
        //            }
        //        case ObjectState.Modified:
        //            {
        //                return EntityState.Modified;
        //            }
        //        case ObjectState.Deleted:
        //            {
        //                return EntityState.Deleted;
        //            }
        //        default:
        //            {
        //                return EntityState.Unchanged;
        //            }
        //    }
        //}
    }
}
