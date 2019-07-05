using System.ComponentModel.DataAnnotations;

namespace Common.Domain
{
    public abstract class BaseLookup : BaseEntity
    {
        [Required]
        public bool IsDefault { get; set; }
    }
}
