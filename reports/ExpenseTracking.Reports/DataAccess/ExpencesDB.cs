using Microsoft.Data.Entity;
using Microsoft.Data.Sqlite;
using System;
using System.Data.SQLite;

namespace ExpenseTracking.Reporting
{
    internal class ExpencesDB : DbContext
    {
        private string myDbFile;

        public DbSet<ExpenceRow> Expenses { get; set; }

        public ExpencesDB(string dbFile)
        {
            myDbFile = dbFile;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SQLiteConnectionStringBuilder { DataSource = myDbFile };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);
            optionsBuilder.UseSqlite(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExpenceRow>().ToTable("expenses");
            modelBuilder.Entity<ExpenceRow>().HasKey(e => e.InvoiceId);
            modelBuilder.Entity<ExpenceRow>().Property(e => e.InvoiceId).HasColumnName("invoiceId");
            modelBuilder.Entity<ExpenceRow>().Property(e => e.Date).HasColumnName("date");
            modelBuilder.Entity<ExpenceRow>().Property(e => e.Category).HasColumnName("category");
            modelBuilder.Entity<ExpenceRow>().Property(e => e.Cost).HasColumnName("cost");
            modelBuilder.Entity<ExpenceRow>().Property(e => e.Memo).HasColumnName("memo");
            base.OnModelCreating(modelBuilder);
        }
    }
}
