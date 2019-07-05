using Common.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Serita.Domain.Local
{
    public class MenuItem : BaseLookupView
    {
        #region Title
        [MaxLength(64)]
        [Required]
        public string Title { get; set; }
        #endregion
        #region IconName
        [MaxLength(32)]
        public string IconName { get; set; }
        #endregion
        #region Parent
        public virtual MenuItem Parent { get; set; }
        public int? ParentId { get; set; }
        #endregion
        #region HasSeparator
        public bool HasSeparator { get; set; }
        #endregion
        #region ShortCut
        [MaxLength(16)]
        public string ShortCut { get; set; }
        #endregion        
        #region IsChecked
        public bool IsChecked { get; set; }
        #endregion
        #region Link
        [MaxLength(64)]
        public string Link { get; set; }
        #endregion
        #region Ordering
        public byte Ordering { get; set; }
        #endregion
        #region Children
        private ICollection<MenuItem> _children;
        public virtual ICollection<MenuItem> Children
        {
            get { return _children ?? (_children = new HashSet<MenuItem>()); }
            set { _children = value; }
        }
        #endregion
    }
}
