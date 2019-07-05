using Serita.Business.Interface;
using Serita.Data.UnitOfWork;
using Serita.Service.Interface;
using Serita.Domain.Local;
using Common.Helper.Exceptions.Logger;
using Common.Helper.Providers.SessionProvider;
using Common.Helper.Resource.Service;
using Common.Helper.Exceptions.Data;
using System;
using System.Collections.Generic;
using Serita.Data.UnitOfWork.Interface;

namespace Serita.Service
{
    public class MenuItemService : IMenuItemService
    {
        ISessionProvider _sessionProvider;
        ISeritaUnitOfWork _seritaUoW;
        IMenuItemBL _menuItemBL;

        public MenuItemService(ISessionProvider sessionProvider, ISeritaUnitOfWork seritaUoW, IMenuItemBL menuItemBL)
        {
            _sessionProvider = sessionProvider;
            _seritaUoW = seritaUoW;
            _menuItemBL = menuItemBL;
        }

        public bool Insert(MenuItem entity)
        {
            entity.Ordering = _menuItemBL.GetLastOrdering(entity.ParentId);
            if (!_menuItemBL.Insert(entity))
                return false;

            return ApplyCommit(Share.Insert_DatabaseException, new { entity.Id, entity.ParentId, _sessionProvider.LanguageId, entity.Title });
        }

        public bool InsertAfter(MenuItem entity, MenuItem after)
        {
            var nextSiblings = _menuItemBL.GetNextSiblings(after);
            foreach(var m in nextSiblings)
            {
                m.Ordering++;
                _menuItemBL.Update(m);
            }
            entity.Ordering = Convert.ToByte(after.Ordering + 1);

            if (!_menuItemBL.Insert(entity))
                return false;

            return ApplyCommit(Share.Insert_DatabaseException, new { entity.Id, entity.ParentId, _sessionProvider.LanguageId, entity.Title });
        }

        private bool ApplyCommit(string exceptionMessage, object loggerObject)
        {
            try
            {
                _seritaUoW.Commit();
                return true;
            }
            catch (DatabaseException ex)
            {
                EventLogger.Error(ex, exceptionMessage, loggerObject);
                throw new Exception(exceptionMessage);
            }
        }

        public bool Update(MenuItem entity)
        {
            if (!_menuItemBL.Update(entity))
                return false;

            return ApplyCommit(Share.Update_DatabaseException, new { entity.Id, entity.ParentId, _sessionProvider.LanguageId, entity.Title });
        }

        public bool Delete(MenuItem entity)
        {
            return this.Delete(entity.Id);
        }

        public bool Delete(int id)
        {
            if (!_menuItemBL.Delete(id))
                return false;

            return ApplyCommit(Share.Delete_DatabaseException, new { id });
        }

        public MenuItem Find(int id)
        {
            return _menuItemBL.Find(id);
        }

        public IEnumerable<MenuItem> GetAll()
        {
            return _menuItemBL.GetAll();
        }

        public IEnumerable<MenuItem> GetMainMenuItems()
        {
            return _menuItemBL.GetMainMenuItems();
        }

        //public bool AddChildren(MenuItem parent, ICollection<MenuItem> children)
        //{
        //    return this.AddChildren(parent.Id, children);
        //}

        //public bool AddChildren(int parentId, ICollection<MenuItem> children)
        //{
        //    bool result = true;
        //    foreach (var menu in children)
        //    {
        //        menu.ParentId = parentId;
        //        if (!_menuItemBL.Insert(menu))
        //            result = false;
        //    }

        //    if (!result)
        //        return false;

        //    return ApplyCommit(Share.Insert_DatabaseException, null);
        //}

        public bool DeleteChildren(MenuItem entity)
        {
            return this.DeleteChildren(entity.Id);
        }

        public bool DeleteChildren(int id)
        {
            bool result = true;
            var children = _menuItemBL.GetChildren(id);
            foreach (var menu in children)
            {
                if (!_menuItemBL.Delete(menu.Id))
                    result = false;
            }

            if (!result)
                return false;

            return ApplyCommit(Share.Delete_DatabaseException, null);
        }

        public IEnumerable<MenuItem> GetChildren(int id)
        {
            return _menuItemBL.GetChildren(id);
        }

        public IEnumerable<MenuItem> GetChildren(MenuItem entity)
        {
            return this.GetChildren(entity.Id);
        }

        public bool ChangeParent(MenuItem entity, int newParentId)
        {
            return this.ChangeParent(entity.Id, newParentId);
        }

        public bool ChangeParent(int id, int newParentId)
        {
            if (!_menuItemBL.ChangeParent(id, newParentId))
                return false;

            return ApplyCommit(Share.Update_DatabaseException, new { id, newParentId });
        }

        public bool MoveUp(MenuItem entity)
        {
            var preMenu = _menuItemBL.GetPreviousSibling(entity);
            if (preMenu == null)
                return true;

            var preMenuOrdering = preMenu.Ordering;
            preMenu.Ordering = entity.Ordering;
            entity.Ordering = preMenuOrdering;

            if (!_menuItemBL.Update(entity))
                return false;
            if (!_menuItemBL.Update(preMenu))
                return false;

            return ApplyCommit(Share.Update_DatabaseException, new { entity.Id, entity.ParentId, entity.Ordering, PreviousId = preMenu.Id, PreviousParentId = preMenu.ParentId, PreviousOrdering = preMenu.Ordering });
        }

        public bool MoveDown(MenuItem entity)
        {
            var nextMenu = _menuItemBL.GetNextSibling(entity);
            if (nextMenu == null)
                return true;

            var nextMenuOrdering = nextMenu.Ordering;
            nextMenu.Ordering = entity.Ordering;
            entity.Ordering = nextMenuOrdering;

            if (!_menuItemBL.Update(entity))
                return false;
            if (!_menuItemBL.Update(nextMenu))
                return false;

            return ApplyCommit(Share.Update_DatabaseException, new { entity.Id, entity.ParentId, entity.Ordering, NextId = nextMenu.Id, NextParentId = nextMenu.ParentId, NextOrdering = nextMenu.Ordering });
        }
    }
}
