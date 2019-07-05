using Serita.Data.Repository.Interface;
using Serita.Domain.Local;
using Common.Data.Repository;
using Common.Data.UnitOfWork.Interface;

namespace Serita.Data.Repository
{
    public class MenuItemTitleRep : BaseRepositoryTitle<MenuItemTitle>, IMenuItemTitleRep
    {
        public MenuItemTitleRep(IUnitOfWork uow) : base(uow)
        {
        }
    }
}
