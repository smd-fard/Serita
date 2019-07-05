using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Common.Data.Repository.Interface
{
    public interface IBase<T> : IDisposable where T : BaseEntity
    {
        IEnumerable<T> Get(Expression<Func<T, bool>> where = null,
                            Expression<Func<T, object>> includes = null,
                            Expression<Func<T, object>> orderBy = null,
                            Expression<Func<T, object>> orderByDesc = null,
                            int? skip = null,
                            int? take = null);

        T GetSingle(Expression<Func<T, bool>> where = null,
                    Expression<Func<T, object>> includes = null,
                    Expression<Func<T, object>> orderBy = null,
                    Expression<Func<T, object>> orderByDesc = null);
    }
}
