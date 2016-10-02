using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracking.Reporting
{
    public class Reports
    {
        private string myDb;

        public Reports(string dbFile)
        {
            myDb = dbFile;
        }

        public class Expense { public string InvoiceId { get; set; } public string Category { get; set; } public DateTime Date { get; set; } public decimal Cost { get; set; } public string Memo { get; set; } }
        private List<Expense> Expenses()
        {
            using (var db = new ExpensesDB(myDb))
            {
                return (from e in db.Expenses
                        select new Expense()
                        {
                            Category = e.Category,
                            Cost = e.Cost,
                            Date = new DateTime(e.Date),
                            InvoiceId = e.InvoiceId,
                            Memo = e.Memo
                        }).ToList<Expense>();
            }
        }

        public List<Expense> OrderedByDate()
        {
            return Expenses().OrderBy((e) => e.Date).ToList<Expense>();
        }

        public class MonthlyExpense { public int Year { get; set; } public int Month { get; set; } public string Category { get; set; } public decimal Total { get; set; } }
        public List<MonthlyExpense> AggregatedByMonthAndCategory()
        {
            return (from e in Expenses()
                    group e by new { e.Date.Year, e.Date.Month, e.Category } into grp
                    select new MonthlyExpense()
                    {
                        Category = grp.Key.Category,
                        Month = grp.Key.Month,
                        Year = grp.Key.Year,
                        Total = grp.Sum(e => e.Cost)
                    }).ToList<MonthlyExpense>();
        }
    }
}
