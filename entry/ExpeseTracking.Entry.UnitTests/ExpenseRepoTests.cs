using System;
using Xunit;
using ExpenseTracking.Entry.Domain;
using ExpenseTracking.Entry.Repository;

namespace ExpeseTracking.Entry.UnitTests
{
    public class ExpenseRepoTests
    {
        [Fact]
        public void repo_adds_expense_to_store()
        {
            var repo = new ExpenseRepo(Guid.NewGuid().ToString());
            repo.Add(new Expense("invoiceRef", DateTime.Now, "gas", 100.11M, "filled some gas"));
            repo.Destroy();
        }

        [Fact]
        public void repo_adds_expense_when_memo_unspecified()
        {
            var repo = new ExpenseRepo(Guid.NewGuid().ToString());
            repo.Add(new Expense("invoiceRef", DateTime.Now, "gas", 100.11M));
            repo.Destroy();
        }
    }
}
