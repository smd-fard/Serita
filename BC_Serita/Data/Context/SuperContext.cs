using Serita.Domain.Config;
using Serita.Domain.Local;
using Serita.Domain.Reference;
using Common.Data.Context;
using Common.Helper.Utilities.Extensions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Common.Helper.Enums;

namespace Serita.Data.Context
{
    public class SuperContext : BaseDbContext<SuperContext>
    {
        public SuperContext(SqliteConnection con) : base(con) {
        }

        public SuperContext() : base(DbName.Serita, Schema.Serita) { }

        protected override void IgnoreReferences(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Language>();
            //base.IgnoreReferences(modelBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new MenuItemTitleConfig());
            //base.AddConfiguration(modelBuilder);
        }

        public DbSet<MenuItemValue> MenuItemValues { get; set; }
        public DbSet<MenuItemTitle> MenuItemTitles { get; set; }
    }
}
