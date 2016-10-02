using ExpenseTracking.Entry.Domain;
using ExpenseTracking.Entry.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExpenseTracking.UI.Desktop
{
    public class ExpenseController
    {
        private ExpenseRepo repo;

        public class DelegateCommand : ICommand
        {
            private readonly Action _action;

            public DelegateCommand(Action action)
            {
                _action = action;
            }

            public void Execute(object parameter)
            {
                _action();
            }

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }
        }


        public ExpenseController()
        {
            this.State = new ViewModel()
            {
                Category = "Category",
                Cost = 0.01M,
                Date = DateTime.Now,
                Invoice = "Invoice",
                Memo = "Memo",
                Notification = "Enter new expense",
                Reports = new List<KeyValuePair<int, string>>()
                {
                    new KeyValuePair<int, string>(0, "Select report"),
                    new KeyValuePair<int, string>(1, "List by date"),
                    new KeyValuePair<int, string>(2, "Aggregated by month and category")
                }
            };
            this.AddExpenseCommand = new DelegateCommand(() => AddExpense());
            this.repo = new ExpenseRepo("2016");
        }

        private void AddExpense()
        {
            try
            {
                repo.Add(new Expense(State.Invoice, State.Date, State.Category, State.Cost, State.Memo));
                State.Notification = $"Expense ({State.Invoice}) saved";
            }
            catch (Exception e)
            {
                State.Notification = e.Message;
            }
        }

        public ViewModel State { get; private set; }
        public ICommand AddExpenseCommand { get; private set; }
    }
}
