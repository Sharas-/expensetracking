using System;

namespace ExpenseTracking.Entry.Domain
{
    /// <summary>
    /// Represents valid expense
    /// </summary>
    public class Expense
    {
        public Expense(Token invoiceId, DateTime when, Token category, SpentAmount cost, string memo = null)
        {
            if(category == null)
            {
                throw new ArgumentNullException("Category cannot be null");
            }
            if(cost == null)
            {
                throw new ArgumentNullException("Cost cannot be null");
            }

            InvoiceId = invoiceId;
            When = when;
            Category = category;
            Cost = cost;
            Memo = memo;
        }

        public Token InvoiceId { get; private set; }
        public DateTime When { get; private set; }
        public string Category { get; private set; }
        public decimal Cost { get; private set; }
        public string Memo { get; private set; }
    }
}
