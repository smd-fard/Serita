using Common.Data.Context;
using Common.Helper.Utilities.Extensions;
using Common.Helper.Enums;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Shared.Domain.Config;
using Shared.Domain.Local;

namespace Shared.Data.Context
{
    public class SuperContext : BaseDbContext<SuperContext>
    {
        public SuperContext(SqliteConnection con) : base(con)
        {
        }

        public SuperContext() : base(DbName.Serita, Schema.Shared) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new StatusTitleConfig());
            //base.AddConfiguration(modelBuilder);
        }

        public DbSet<Language> Languages { get; set; }
        public DbSet<StatusValue> StatusValues { get; set; }
        public DbSet<StatusTitle> StatusTitles { get; set; }
    }
}
