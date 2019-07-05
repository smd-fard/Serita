using Serita.Data.Repository.Interface;
using Serita.Domain.Local;
using Common.Data.Repository;
using Common.Data.UnitOfWork.Interface;

namespace Serita.Data.Repository
{
    public class MenuItemValueRep : BaseRepository<MenuItemValue>, IMenuItemValueRep
    {
        public MenuItemValueRep(IUnitOfWork uow) : base(uow)
        {
        }
    }
}
