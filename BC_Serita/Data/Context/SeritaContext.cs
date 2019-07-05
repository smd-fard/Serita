using Serita.Domain.Local;
using Serita.Domain.Reference;
using Common.Helper.Enums;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Serita.Data.Context
{
    public class SeritaContext : SuperContext
    {
        public SeritaContext(SqliteConnection con) : base(con) {
            IgnoreReferenceEntities = false;
        }

        public SeritaContext() : base(){
            IgnoreReferenceEntities = false;
        }

        protected override void ApplyReferenceEntityName(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>().ToTable("LanguagesRef" + Schema.Shared.ToString(), Schema.Serita.ToString());
            //base.ApplyViewName(modelBuilder);
        }

        public DbSet<MenuItem> MenuItems { get; set; }

        #region Reference Entities
        public DbSet<Language> Languages { get; set; }
        #endregion
    }
}
