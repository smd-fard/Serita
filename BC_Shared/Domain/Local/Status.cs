using Common.Domain;
using System.ComponentModel.DataAnnotations;

namespace Shared.Domain.Local
{
    public class Status : BaseLookup
    {
        [MaxLength(64)]
        public string Title { get; set; }

        public int LanguageId { get; set; }
    }
}
