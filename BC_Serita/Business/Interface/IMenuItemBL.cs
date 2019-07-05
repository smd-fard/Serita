using Serita.Domain.Local;
using System.Collections.Generic;

namespace Serita.Business.Interface
{
    public interface IMenuItemBL
    {
        bool Insert(MenuItem entity);
        bool Update(MenuItem entity);
        bool Delete(int id);
        MenuItem Find(int id);
        int GetFirstFreeId(int? parentId);
        byte GetLastOrdering(int? parentId);
        IEnumerable<MenuItem> GetAll();
        IEnumerable<MenuItem> GetMainMenuItems();
        IEnumerable<MenuItem> GetChildren(int id);
        bool ChangeParent(int id, int newParentId);
        MenuItem GetNextSibling(MenuItem entity);
        IEnumerable<MenuItem> GetNextSiblings(MenuItem entity);
        MenuItem GetPreviousSibling(MenuItem entity);
        IEnumerable<MenuItem> GetPreviousSiblings(MenuItem entity);
    }
}
