using ExpenseTracking.Entry.Domain;
using ExpenseTracking.Entry.Repository;
using ExpenseTracking.Reporting;
using System;
using Xunit;

namespace ExpenseTracking.Tests.Integration
{
    public class ReportsTests
    {
        [Fact]
        public void ordered_by_date_returns_all_expenses()
        {
            var storeId = Guid.NewGuid().ToString();
            var repo = new ExpenseRepo(storeId);
            repo.Add(new Expense("Invoice1", DateTime.Now, "gas", 99.9M));
            repo.Add(new Expense("Invoice2", DateTime.Now, "entertainment", 40009M));
            repo.Add(new Expense("Invoice3", DateTime.Now, "hardware", 500.39M));
            var allEntries = new Reports($"{storeId}.sqlite").OrderedByDate();
            Assert.Equal(3, allEntries.Count);
            repo.Destroy();
        }

        [Fact]
        public void aggregated_by_month_and_category_sums_amounts()
        {
            var storeId = Guid.NewGuid().ToString();
            var category = "gas";
            var repo = new ExpenseRepo(storeId);
            repo.Add(new Expense("Invoice1", DateTime.Now, category, 10M));
            repo.Add(new Expense("Invoice2", DateTime.Now, category, 40M));
            var allEntries = new Reports($"{storeId}.sqlite").AggregatedByMonthAndCategory();
            Assert.Equal(1, allEntries.Count);
            Assert.Equal(category, allEntries[0].Category);
            Assert.Equal(50M, allEntries[0].Total);
            repo.Destroy();
        }

    }
}
