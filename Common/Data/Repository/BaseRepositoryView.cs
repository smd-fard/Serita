using Common.Data.Repository.Interface;
using Common.Data.UnitOfWork.Interface;
using Common.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Common.Data.Repository
{
    public abstract class BaseRepositoryView<T> : Base<T>, IRepositoryView<T> where T : BaseEntity
    {
        public BaseRepositoryView(IUnitOfWork uow):base(uow)
        {
        }

        public virtual T Find(int id)
        {
            return _dbSet.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
    }
}
