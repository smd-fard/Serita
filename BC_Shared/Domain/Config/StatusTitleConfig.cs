using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Domain.Local;

namespace Shared.Domain.Config
{
    public class StatusTitleConfig : IEntityTypeConfiguration<StatusTitle>
    {
        public void Configure(EntityTypeBuilder<StatusTitle> builder)
        {
            builder.HasKey(x => new { x.Id, x.LanguageId });
        }
    }
}
