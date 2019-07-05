using Serita.Domain.Local;
using System.Collections.Generic;

namespace Serita.Service.Interface
{
    public interface IMenuItemService
    {
        bool Insert(MenuItem entity);
        bool InsertAfter(MenuItem entity, MenuItem after);
        bool Update(MenuItem entity);
        bool Delete(MenuItem entity);
        bool Delete(int id);
        MenuItem Find(int id);
        IEnumerable<MenuItem> GetAll();
        IEnumerable<MenuItem> GetMainMenuItems();
        //bool AddChildren(MenuItem parent, ICollection<MenuItem> children);
        //bool AddChildren(int parentId, ICollection<MenuItem> children);
        bool DeleteChildren(MenuItem entity);
        bool DeleteChildren(int id);
        IEnumerable<MenuItem> GetChildren(MenuItem entity);
        IEnumerable<MenuItem> GetChildren(int id);
        bool ChangeParent(MenuItem entity, int newParentId);
        bool ChangeParent(int id, int newParentId);
        bool MoveUp(MenuItem entity);
        bool MoveDown(MenuItem entity);
    }
}
