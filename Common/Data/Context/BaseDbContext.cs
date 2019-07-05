using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Data.Sqlite;
using Common.Domain;
using Common.Helper.Enums;
using Common.Helper.Utilities.Extensions;
using Common.Helper.Exceptions.Data;

namespace Common.Data.Context
{
    public class BaseDbContext<T> : DbContext where T : DbContext
    {
        private DbName _dbName = DbName.None;
        private Schema _schema = Schema.None;

        private bool RunInTestMode = false;
        protected bool IgnoreReferenceEntities = true;

        public BaseDbContext(SqliteConnection con) : base(new DbContextOptionsBuilder<T>().UseSqlite(con).Options)
        {
            RunInTestMode = true;
        }

        public BaseDbContext(DbName dbName, Schema schema)
        {
            _dbName = dbName;
            _schema = schema;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!RunInTestMode)
            {
                var conString = @"Server=.;DataBase=" + _dbName.ToString() + ";User=sa;Password=1234512345;";
                optionsBuilder.UseSqlServer(conString, x => x.MigrationsHistoryTable(HistoryRepository.DefaultTableName, _schema.ToString()));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ApplyConfiguration(modelBuilder);

            if (IgnoreReferenceEntities)
            {
                IgnoreReferences(modelBuilder);
            }

            if (!RunInTestMode)
            {
                ApplyReferenceEntityName(modelBuilder);
                modelBuilder.HasDefaultSchema(_schema.ToString());
            }

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (entityType.ClrType.BaseType == typeof(BaseLookup))
                {
                    entityType.FindProperty("Id").ValueGenerated = Microsoft.EntityFrameworkCore.Metadata.ValueGenerated.Never;
                }
            }

            //modelBuilder.Entity(typeof(BaseEntity)).Property("State").IsRequired(true);
            //modelBuilder.Entity<BaseEntity>().Ignore(x => x.State);

            //???
            //modelBuilder.Ignore<BaseLookup>();

            //modelBuilder.Ignore<BaseLookupTitle>();

            base.OnModelCreating(modelBuilder);
        }

        protected internal virtual void ApplyConfiguration(ModelBuilder modelBuilder)
        {

        }

        protected internal virtual void ApplyReferenceEntityName(ModelBuilder modelBuilder)
        {

        }

        protected internal virtual void IgnoreReferences(ModelBuilder modelBuilder)
        {

        }

        protected internal virtual void AddConfiguration(ModelBuilder modelBuilder)
        {

        }

        public override int SaveChanges()
        {
            //this.FixState();
            this.FixDate();
            try
            {
                return base.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new DatabaseException(GetExceptionCaption(ex));
            }
        }

        private string GetExceptionCaption(Exception ex)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }

            return ex.Message;
        }
    }
}
