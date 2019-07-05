//using AutoMapper;
using Serita.Business.Interface;
using Serita.Business.Variable;
using Serita.Data.Repository.Interface;
using Serita.Domain.Local;
using Common.Helper.Resource.Business;
using Common.Helper.Providers.SessionProvider;
using Common.Helper.Validations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Serita.Business
{
    public class MenuItemBL : IMenuItemBL
    {
        ISessionProvider _sessionProvider;
        IValidationDictionary _validationDictionary;

        IMenuItemRep _menuRep;
        IMenuItemValueRep _valueRep;
        IMenuItemTitleRep _titleRep;

        public MenuItemBL(ISessionProvider sessionProvider, IValidationDictionary validationDictionary, IMenuItemRep menuRep, IMenuItemValueRep valueRep, IMenuItemTitleRep titleRep)
        {
            _sessionProvider = sessionProvider;
            _validationDictionary = validationDictionary;

            _menuRep = menuRep;
            _valueRep = valueRep;
            _titleRep = titleRep;
            
            //Mapper.Initialize(x =>
            //{
            //    x.CreateMap<MenuItemDto, MenuItem>().BeforeMap((s, d) => d.LanguageId = _sessionProvider.LanguageId).ReverseMap();
            //});
        }

        public bool Insert(MenuItem entity)
        {
            TrimTitle(entity);
            entity.Id = this.GetFirstFreeId(entity.ParentId);

            if (!InsertValidation(entity))
                return false;

            // AutoMap
            //var menu = Mapper.Map<MenuItem>(entity);

            // Insert into MenuItemValue if it is not exist.
            // It will be exist if new title is going to insert into MenuItemTitle (new language title).
            var val = _valueRep.Find(entity.Id);
            if (val == null)
            {
                var value = MenuItemValue.Create(entity);
                _valueRep.Insert(value);
            }

            var title = MenuItemTitle.Create(entity);
            _titleRep.Insert(title);

            return true;
        }

        private bool InsertValidation(MenuItem entity)
        {
            bool result = true;

            if (!CheckTitleLenght(entity.Title))
                result = false;

            if (!CheckDuplicateTitle(entity.ParentId, entity.Title))
                result = false;

            return result;
        }

        private bool CheckTitleLenght(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                _validationDictionary.AddError("Title", Share.Null_Or_Empty);
                return false;
            }

            return true;
        }

        private bool CheckDuplicateTitle(int? parentId, string title)
        {
            var menuItem = _menuRep.Get(x => x.ParentId == parentId && x.Title == title && x.LanguageId == _sessionProvider.LanguageId);
            if (menuItem.Count() > 0)
            {
                _validationDictionary.AddError("Title", Share.Duplicate_Title);
                return false;
            }
            return true;
        }

        public bool Update(MenuItem entity)
        {
            TrimTitle(entity);

            if (!UpdateValidation(entity))
                return false;

            // AutoMap
            //var menu = Mapper.Map<MenuItem>(entity);

            var value = _valueRep.Find(id: entity.Id);
            MenuItemValue.Update(entity, ref value);

            var title = _titleRep.Find(id: entity.Id, languageId: _sessionProvider.LanguageId);
            MenuItemTitle.Update(entity, ref title);

            _valueRep.Update(value);
            _titleRep.Update(title);

            return true;
        }

        private bool UpdateValidation(MenuItem entity)
        {
            bool result = true;

            if (!CheckTitleLenght(entity.Title))
                result = false;

            if (!CheckMenuItemIsExist(entity.Id))
                result = false;

            if (!CheckDuplicateTitleForUpdate(entity.Id, entity.ParentId, entity.Title))
                result = false;

            return result;
        }

        private bool CheckMenuItemIsExist(int id)
        {
            var menuItem = _menuRep.Find(id, _sessionProvider.LanguageId);
            if (menuItem == null)
            {
                _validationDictionary.AddError("Entity", Share.Entity_Not_Found);
                return false;
            }
            return true;
        }

        private bool CheckDuplicateTitleForUpdate(int id, int? parentId, string title)
        {
            var menuItem = _menuRep.Get(x => x.Id != id && x.ParentId == parentId && x.Title == title && x.LanguageId == _sessionProvider.LanguageId);
            if (menuItem.Count() > 0)
            {
                _validationDictionary.AddError("Title", Share.Duplicate_Title);
                return false;
            }
            return true;
        }

        public bool Delete(int id)
        {
            if (!DeleteValidation(id))
                return false;

            // deleting Value will delete all Titles, too. (Titles in different languages)
            _valueRep.Delete(id);

            return true;
        }

        private bool DeleteValidation(int id)
        {
            bool result = true;

            var menuItem = _menuRep.GetSingle(x => x.Id == id);
            if (!CheckMenuItemIsExistForDelete(menuItem))
                return false;
                // if entity does not exist, so there is no need to check other validations.
                // result = false;

            if (!CheckMenuItemIsDefault(menuItem))
                result = false;

            return result;
        }

        private bool CheckMenuItemIsExistForDelete(MenuItem entity)
        {
            if (entity == null)
            {
                _validationDictionary.AddError("Entity", Share.Entity_Not_Found);
                return false;
            }
            return true;
        }

        private bool CheckMenuItemIsDefault(MenuItem entity)
        {
            if (entity.IsDefault)
            {
                _validationDictionary.AddError("Entity", Share.Is_Default);
                return false;
            }
            return true;
        }

        public MenuItem Find(int id)
        {
            var menu = _menuRep.Find(id, _sessionProvider.LanguageId);

            // AutoMap
            //var menuDto = Mapper.Map<MenuItemDto>(menu);
            //return menuDto;
            return menu;
        }

        public IEnumerable<MenuItem> GetAll()
        {
            var menus = _menuRep.Get(where: x => x.LanguageId == _sessionProvider.LanguageId);

            // AutoMap
            //var menuDtos = Mapper.Map<ICollection<MenuItemDto>>(menus);

            return menus;
        }

        public IEnumerable<MenuItem> GetMainMenuItems()
        {
            var menus = _menuRep.Get(where: x => x.ParentId == null && x.LanguageId == _sessionProvider.LanguageId, orderBy: x => x.Ordering);

            // AutoMap
            //var menuDtos = Mapper.Map<ICollection<MenuItemDto>>(menus);

            return menus;
        }

        public IEnumerable<MenuItem> GetChildren(int id)
        {
            var menus = _menuRep.Get(where: x => x.ParentId == id && x.LanguageId == _sessionProvider.LanguageId, orderBy: x => x.Ordering);

            // AutoMap
            //var menuDtos = Mapper.Map<ICollection<MenuItemDto>>(menus);

            return menus;
        }

        public bool ChangeParent(int id, int newParentId)
        {
            if (!ParentIsExist(newParentId))
                return false;

            var menuValue = _valueRep.Find(id: id);
            menuValue.ParentId = newParentId;
            _valueRep.Update(menuValue);

            return true;
        }

        private bool ParentIsExist(int id)
        {
            var menuValue = _valueRep.Find(id);
            if (menuValue == null)
            {
                _validationDictionary.AddError("Entity", Share.Entity_Not_Found);
                return false;
            }
            return true;
        }

        private void TrimTitle(MenuItem entity)
        {
            if (entity.Title != null)
            {
                entity.Title = entity.Title.Trim();
            }
        }

        public int GetFirstFreeId(int? parentId)
        {
            var menu = _menuRep.GetSingle(where: x => x.LanguageId == _sessionProvider.LanguageId && x.ParentId == parentId, orderByDesc: x => x.Id);
            if (menu != null)
                return menu.Id + 1;

            return Convert.ToInt32(parentId.ToString() + Constant.MENUITEM_SUB_CODE_START_NUMBER);
        }

        public byte GetLastOrdering(int? parentId)
        {
            var menu = _menuRep.GetSingle(where: x => x.LanguageId == _sessionProvider.LanguageId && x.ParentId == parentId, orderByDesc: x => x.Ordering);
            if (menu != null)
                return Convert.ToByte(menu.Ordering + 1);

            return 0;
        }

        public MenuItem GetNextSibling(MenuItem entity)
        {
            var menu = _menuRep.GetSingle(where: x => x.LanguageId == _sessionProvider.LanguageId && x.ParentId == entity.ParentId && x.Ordering > entity.Ordering, orderBy: x => x.Ordering);

            // AutoMap
            //var menuDto = Mapper.Map<MenuItemDto>(menu);

            return menu;
        }

        public IEnumerable<MenuItem> GetNextSiblings(MenuItem entity)
        {
            var menus = _menuRep.Get(where: x => x.LanguageId == _sessionProvider.LanguageId && x.ParentId == entity.ParentId && x.Ordering > entity.Ordering, orderBy: x => x.Ordering);

            // AutoMap
            //var menuDtos = Mapper.Map<ICollection<MenuItemDto>>(menus);

            return menus;
        }

        public MenuItem GetPreviousSibling(MenuItem entity)
        {
            var menu = _menuRep.GetSingle(where: x => x.LanguageId == _sessionProvider.LanguageId && x.ParentId == entity.ParentId && x.Ordering < entity.Ordering, orderBy: x => x.Ordering);

            // AutoMap
            //var menuDto = Mapper.Map<MenuItemDto>(menu);

            return menu;
        }

        public IEnumerable<MenuItem> GetPreviousSiblings(MenuItem entity)
        {
            var menus = _menuRep.Get(where: x => x.LanguageId == _sessionProvider.LanguageId && x.ParentId == entity.ParentId && x.Ordering < entity.Ordering, orderBy: x => x.Ordering);

            // AutoMap
            //var menuDtos = Mapper.Map<ICollection<MenuItemDto>>(menus);

            return menus;
        }
    }
}