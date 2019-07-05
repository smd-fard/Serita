using Common.Domain;
using Common.Data.Repository.Interface;
using Common.Data.UnitOfWork.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Common.Data.Repository
{
    public abstract class BaseRepository<T> : Base<T>, IRepository<T> where T : BaseEntity
    {
        public BaseRepository(IUnitOfWork uow) : base(uow)
        {
        }

        public virtual void Insert(T entity)
        {
            _uow.Entry(entity).State = EntityState.Added;
        }

        public virtual void Update(T entity)
        {
            _uow.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void Delete(int id)
        {
            var entity = this.Find(id);
            _dbSet.Remove(entity);
        }

        public virtual T Find(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }
    }
    /*
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected IUnitOfWork _uow { get; set; }
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(IUnitOfWork uow)
        {
            _uow = uow;
            _dbSet = uow.Set<T>();
        }

        public virtual void Insert(T entity)
        {
            entity.State = ObjectState.Added;
            _dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            entity.State = ObjectState.Modified;
            _dbSet.Attach(entity);
            
            //_uow.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            entity.State = ObjectState.Deleted;
            _dbSet.Remove(entity);
        }

        public virtual void Delete(int id)
        {
            var entity = this.Find(id);
            entity.State = ObjectState.Deleted;
            _dbSet.Remove(entity);
        }

        public virtual T Find(int id)
        {
            return _dbSet.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> where = null,
                                            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                            //IList<Expression<Func<T, BaseLookupEntity>>> include = null,
                                            string includes = null,
                                            int? skip = null,
                                            int? take = null)
        {
            includes = includes ?? string.Empty;
            IQueryable<T> query = _dbSet;

            if (where != null)
            {
                query = query.Where(where);
            }

            foreach (var include in includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(include);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

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

        public void Dispose()
        {
            _uow.Dispose();
        }
    }
    */
}
