using Common.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Serita.Domain.Local
{
    public class MenuItemValue : BaseLookup
    {
        public static MenuItemValue Create(MenuItem entity)
        {
            return new MenuItemValue()
            {
                Id = entity.Id,
                ParentId = entity.ParentId,
                IconName = entity.IconName,
                IsChecked = entity.IsChecked,
                IsDefault = entity.IsDefault,
                Link = entity.Link,
                ShortCut = entity.ShortCut,
                HasSeparator = entity.HasSeparator,
                Ordering = entity.Ordering
            };
        }

        public static void Update(MenuItem entity, ref MenuItemValue menuItemValue)
        {
            menuItemValue.Id = entity.Id;
            menuItemValue.ParentId = entity.ParentId;
            menuItemValue.IconName = entity.IconName;
            menuItemValue.IsChecked = entity.IsChecked;
            menuItemValue.IsDefault = entity.IsDefault;
            menuItemValue.Link = entity.Link;
            menuItemValue.ShortCut = entity.ShortCut;
            menuItemValue.HasSeparator = entity.HasSeparator;
            menuItemValue.Ordering = entity.Ordering;
        }

        #region IconName
        [MaxLength(32)]
        public string IconName { get; set; }
        #endregion
        #region Parent
        public virtual MenuItemValue Parent { get; set; }
        public int? ParentId { get; set; }
        #endregion
        #region HasSeparator
        public bool HasSeparator { get; set; }
        #endregion
        #region ShortCut
        [MaxLength(16)]
        [Column(TypeName = "varchar(16)")]
        public string ShortCut { get; set; }
        #endregion        
        #region IsChecked
        public bool IsChecked { get; set; }
        #endregion
        #region Link
        [MaxLength(64)]
        [Column(TypeName = "varchar(64)")]
        public string Link { get; set; }
        #endregion
        #region Ordering
        public byte Ordering { get; set; }
        #endregion

        #region Children
        private ICollection<MenuItemValue> _children;
        public virtual ICollection<MenuItemValue> Children
        {
            get { return _children ?? (_children = new HashSet<MenuItemValue>()); }
            set { _children = value; }
        }
        #endregion
    }
}
