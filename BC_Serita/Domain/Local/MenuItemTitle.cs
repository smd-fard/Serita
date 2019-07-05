using Serita.Domain.Reference;
using Common.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace Serita.Domain.Local
{
    public class MenuItemTitle : BaseLookupTitle
    {
        public static MenuItemTitle Create(MenuItem entity)
        {
            return new MenuItemTitle()
            {
                Id = entity.Id,
                LanguageId = entity.LanguageId,
                Title = entity.Title
            };
        }

        public static void Update(MenuItem entity, ref MenuItemTitle menuItemTitle)
        {
            menuItemTitle.Title = entity.Title;
        }

        #region MenuItemValue
        [ForeignKey("Id")]
        public virtual MenuItemValue MenuItemValue { get; set; }
        #endregion
        #region Language
        public virtual Language Language { get; set; }
        #endregion
    }
}
