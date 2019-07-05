using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Common.Data.Repository.Interface;
using Common.Data.UnitOfWork.Interface;
using Common.Domain;

namespace Common.Data.Repository
{
    public abstract class Base<T> : IBase<T> where T : BaseEntity
    {
        protected IUnitOfWork _uow { get; set; }
        protected readonly DbSet<T> _dbSet;

        public Base(IUnitOfWork uow)
        {
            _uow = uow;
            _dbSet = uow.Set<T>();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> where = null, Expression<Func<T, object>> includes = null, Expression<Func<T, object>> orderBy = null, Expression<Func<T, object>> orderByDesc = null, int? skip = null, int? take = null)
        {
            //includes = includes ?? string.Empty;
            IQueryable<T> query = _dbSet;

            if (where != null)
            {
                query = query.Where(where);
            }

            if (includes != null)
            {
                query = query.Include(includes);
            }
            //foreach (var include in includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            //{
                //query = query.Include(include);
            //}

            if (orderBy != null)
            {
                query = query.OrderBy(orderBy);
            }

            if (orderByDesc != null)
            {
                query = query.OrderByDescending(orderByDesc);
            }

            //if (orderBy != null)
            //{
            //    query = orderBy(query);
            //}

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query.AsNoTracking().ToList();
        }

        //public virtual T GetSingle(Expression<Func<T, bool>> where = null, string includes = null, Expression<Func<T, object>> orderBy = null, Expression<Func<T, object>> orderByDesc = null)
        public virtual T GetSingle(Expression<Func<T, bool>> where = null, Expression<Func<T, object>> includes = null, Expression<Func<T, object>> orderBy = null, Expression<Func<T, object>> orderByDesc = null)
        {
            //includes = includes ?? string.Empty;
            IQueryable<T> query = _dbSet;

            if (where != null)
            {
                query = query.Where(where);
            }

            //foreach (var include in includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            if (includes != null)
            {
                query = query.Include(includes);
            }

            if (orderBy != null)
            {
                query = query.OrderBy(orderBy);
            }

            if (orderByDesc != null)
            {
                query = query.OrderByDescending(orderByDesc);
            }

            return query.AsNoTracking().FirstOrDefault();
        }

        public void Dispose()
        {
            _uow.Dispose();
        }
    }
}
