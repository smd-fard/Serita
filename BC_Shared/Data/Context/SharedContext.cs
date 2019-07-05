using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Shared.Domain.Local;

namespace Shared.Data.Context
{
    public class SharedContext : SuperContext
    {
        public SharedContext(SqliteConnection con) : base(con)
        {
            IgnoreReferenceEntities = false;
        }

        public SharedContext() : base()
        {
            IgnoreReferenceEntities = false;
        }

        public DbSet<Status> Statuses { get; set; }
    }

    //public class SharedContext : BaseDbContext<SharedContext>
    //{
    //    public SharedContext(SqliteConnection con) : base(con) {            
    //    }

    //    public SharedContext() : base(DbName.CoSMoS, Schema.Shared) { }

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        //if (!RunInTestMode)
    //        {
    //            modelBuilder.Ignore<Status>();
    //        }

    //        modelBuilder.AddConfiguration(new StatusTitleConfig());
            
    //        base.OnModelCreating(modelBuilder);
    //    }

    //    public DbSet<Language> Languages { get; set; }
    //    public DbSet<Status> Statuses { get; set; }
    //    public DbSet<StatusValue> StatusValues { get; set; }
    //    public DbSet<StatusTitle> StatusTitles { get; set; }
    //}
}
