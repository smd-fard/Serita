using Common.Data.Repository.Interface;
using Common.Data.UnitOfWork.Interface;
using Common.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Common.Data.Repository
{
    /*
    public abstract class BaseRepositoryTitle<T> : IRepositoryTitle<T> where T : BaseLookupTitle
    {
        protected IUnitOfWork _uow { get; set; }
        protected readonly DbSet<T> _dbSet;

        public BaseRepositoryTitle(IUnitOfWork uow)
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

        public virtual void Delete(int id, int languageId)
        {
            var entity = this.Find(id, languageId);
            entity.State = ObjectState.Deleted;
            _dbSet.Remove(entity);
        }

        public virtual T Find(int id, int languageId)
        {
            return _dbSet.AsNoTracking().FirstOrDefault(x => x.Id == id && x.LanguageId == languageId);
        }

        public virtual IEnumerable<T> Get(int languageId)
        {
            return _dbSet.Where(x => x.LanguageId == languageId).AsNoTracking().ToList();
        }

        public void Dispose()
        {
            _uow.Dispose();
        }
    }
    */
        public abstract class BaseRepositoryTitle<T> : Base<T>, IRepositoryTitle<T> where T : BaseLookupTitle
    {
        public BaseRepositoryTitle(IUnitOfWork uow): base(uow)
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

        public virtual void Delete(int id, int languageId)
        {
            var entity = this.Find(id, languageId);
            _dbSet.Remove(entity);
        }

        public virtual T Find(int id, int languageId)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id && x.LanguageId == languageId);
        }
    }
}
