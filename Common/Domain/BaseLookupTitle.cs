using System;
using System.ComponentModel.DataAnnotations;

namespace Common.Domain
{
    public abstract class BaseLookupTitle : BaseEntity
    {
        [Required]
        [MaxLength(64)]
        public string Title { get; set; }

        public int LanguageId { get; set; }
    }
}
