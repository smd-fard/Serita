using Common.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace Common.Data.UnitOfWork.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        DbSet<T> Set<T>() where T : BaseEntity;
        EntityEntry<T> Entry<T>(T entity) where T : BaseEntity;
        int Commit();
    }
}
