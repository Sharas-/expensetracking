using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracking.Reporting
{
    internal class ExpenseRow
    {
        public string InvoiceId { get; set; }
        public string Category { get; set; }
        public long Date { get; set; }
        public decimal Cost { get; set; }
        public string Memo { get; set; }
    }
}
