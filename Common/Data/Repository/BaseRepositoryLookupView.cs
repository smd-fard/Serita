using Common.Data.Repository.Interface;
using Common.Data.UnitOfWork.Interface;
using Common.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Common.Data.Repository
{
    public abstract class BaseRepositoryLookupView<T> : Base<T>, IRepositoryLookupView<T> where T : BaseLookupView
    {
        public BaseRepositoryLookupView(IUnitOfWork uow) : base(uow)
        {
        }

        public virtual T Find(int id, int languageId)
        {
            return _dbSet.AsNoTracking().FirstOrDefault(x => x.Id == id && x.LanguageId == languageId);
        }
    }
}
