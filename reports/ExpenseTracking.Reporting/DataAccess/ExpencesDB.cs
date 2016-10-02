using Microsoft.Data.Entity;
using Microsoft.Data.Sqlite;
using System;
using System.Data.SQLite;

namespace ExpenseTracking.Reporting
{
    internal class ExpensesDB : DbContext
    {
        private string myDbFile;

        public DbSet<ExpenseRow> Expenses { get; set; }

        public ExpensesDB(string dbFile)
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
            modelBuilder.Entity<ExpenseRow>().ToTable("expenses");
            modelBuilder.Entity<ExpenseRow>().HasKey(e => e.InvoiceId);
            modelBuilder.Entity<ExpenseRow>().Property(e => e.InvoiceId).HasColumnName("invoiceId");
            modelBuilder.Entity<ExpenseRow>().Property(e => e.Date).HasColumnName("date");
            modelBuilder.Entity<ExpenseRow>().Property(e => e.Category).HasColumnName("category");
            modelBuilder.Entity<ExpenseRow>().Property(e => e.Cost).HasColumnName("cost");
            modelBuilder.Entity<ExpenseRow>().Property(e => e.Memo).HasColumnName("memo");
            base.OnModelCreating(modelBuilder);
        }
    }
}
