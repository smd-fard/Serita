using Common.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Serita.Model
{
    public class MenuItemDto : BaseEntity
    {
        [MaxLength(64)]
        [Required]
        public string Title { get; set; }

        [MaxLength(32)]
        public string IconName { get; set; }

        public virtual MenuItemDto Parent { get; set; }
        public int? ParentId { get; set; }

        public bool HasSeparator { get; set; }

        [MaxLength(16)]
        public string ShortCut { get; set; }

        public bool IsChecked { get; set; }

        [MaxLength(64)]
        public string Link { get; set; }

        public byte Ordering { get; set; }

        private ICollection<MenuItemDto> _children;
        public virtual ICollection<MenuItemDto> Children
        {
            get { return _children ?? (_children = new HashSet<MenuItemDto>()); }
            set { _children = value; }
        }
    }
}
