using Common.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Domain.Local
{
    public class Language : BaseLookup
    {
        [Required]
        [MaxLength(32)]
        public string Title { get; set; }
        
        [Column(TypeName = "char(2)")]
        public string Code { get; set; }
    }
}
