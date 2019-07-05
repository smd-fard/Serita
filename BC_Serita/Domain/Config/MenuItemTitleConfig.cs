using Serita.Domain.Local;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Serita.Domain.Config
{
    public class MenuItemTitleConfig : IEntityTypeConfiguration<MenuItemTitle>
    {
        public void Configure(EntityTypeBuilder<MenuItemTitle> builder)
        {
            builder.HasKey(x => new { x.Id, x.LanguageId });
        }
    }
}
