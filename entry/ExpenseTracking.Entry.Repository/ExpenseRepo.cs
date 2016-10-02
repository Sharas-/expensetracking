using System;
using System.IO;
using ExpenseTracking.Entry.Domain;
using System.Data.SQLite;


namespace ExpenseTracking.Entry.Repository
{
    /// <summary>
    /// Durable expense store
    /// </summary>
    public class ExpenseRepo
    {
        private enum expenses { invoiceId, date, category, cost, memo };

        private string createTableSQL = $"CREATE TABLE {nameof(expenses)}(" +
                                            $"{nameof(expenses.invoiceId)} TEXT PRIMARY KEY," +
                                            $"{nameof(expenses.date)} INEGER," +
                                            $"{nameof(expenses.category)} TEXT," +
                                            $"{nameof(expenses.cost)} REAL, " +
                                            $"{nameof(expenses.memo)} TEXT)";


        //TBD: do insert with sql quoted params
        private string insertSQL = $"INSERT INTO {nameof(expenses)}" + " VALUES(\"{0}\", {1}, \"{2}\", {3}, \"{4}\")";
        private FileInfo dbPath;

        /// <summary>
        /// Creates new store if store with provided databaseID does not exist, or manipulates existing store.
        /// </summary>
        /// <param name="databaseID">ID of store</param>
        public ExpenseRepo(Token databaseID)
        {
            if (databaseID == null)
            {
                throw new ArgumentNullException("Cannot create repo without database ID");
            }
            dbPath = makeDbPath(databaseID);
            if (!dbPath.Exists)
            {
                IntitDb(dbPath);
            }
        }
        /// <summary>
        /// Inserts expense into the store 
        /// </summary>
        /// <param name="e"></param>
        public void Add(Expense e)
        {
            if (e == null)
            {
                throw new ArgumentNullException("cannot add null expense");
            }
            RunSQL(string.Format(insertSQL, e.InvoiceId, e.When.Ticks, e.Category, e.Cost, e.Memo));
        }
        /// <summary>
        /// Deletes this store
        /// </summary>
        public void Destroy()
        {
            dbPath.Delete();
        }

        private void IntitDb(FileInfo dbPath)
        {
            try
            {
                SQLiteConnection.CreateFile(dbPath.FullName);
                RunSQL(createTableSQL);
            }
            catch (Exception)
            {
                Destroy();
                throw;
            }
        }

        private FileInfo makeDbPath(Token databaseID)
        {
            return new FileInfo($"{databaseID}.sqlite");
        }

        private int RunSQL(string sql)
        {
            using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }

}
