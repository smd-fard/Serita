using Serita.Data.Repository.Interface;
using Serita.Domain.Local;
using Common.Data.Repository;
using Common.Data.UnitOfWork.Interface;

namespace Serita.Data.Repository
{
    public class MenuItemRep : BaseRepositoryLookupView<MenuItem>, IMenuItemRep
    {
        public MenuItemRep(IUnitOfWork uow) : base(uow)
        {
        }
    }
}