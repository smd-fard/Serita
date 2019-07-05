using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.Helper.Configurations
{
    public abstract class EntityTypeConfiguration<TEntity> where TEntity : class 
    {
        public abstract void Config(EntityTypeBuilder<TEntity> builder);
    }
}
