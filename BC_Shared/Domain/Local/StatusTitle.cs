using Common.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Domain.Local
{
    public class StatusTitle : BaseLookupTitle
    {
        [ForeignKey("Id")]
        public virtual StatusValue StatusValue { get; set; }

        public virtual Language Language { get; set; }
    }
}
