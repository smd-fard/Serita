using Common.Domain;

namespace Serita.Domain.Reference
{
    public class Language : BaseEntity
    {
        public string Title { get; private set; }
        public string Code { get; private set; }
    }
}
