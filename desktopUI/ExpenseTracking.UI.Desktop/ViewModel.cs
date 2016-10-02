using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracking.UI.Desktop
{
    public class ViewModel : INotifyPropertyChanged
    {
        private string myInvoice;
        private string myCategory;
        private decimal myCost;
        private string myMemo;
        private DateTime myDate;
        private string myNotification;
        private List<KeyValuePair<int, string>> myReports;

        public string Invoice
        {
            get
            {
                return myInvoice;
            }
            set
            {
                if (value != this.myInvoice)
                {
                    this.myInvoice = value;
                    NotifyPropertyChanged();
                };
            }
        }
        public string Category
        {
            get
            {
                return myCategory;
            }
            set
            {
                if (value != this.myCategory)
                {
                    this.myCategory = value;
                    NotifyPropertyChanged();
                };
            }
        }
        public decimal Cost
        {
            get
            {
                return myCost;
            }
            set
            {
                if (value != this.myCost)
                {
                    this.myCost = value;
                    NotifyPropertyChanged();
                };
            }
        }

        public string Memo
        {
            get
            {
                return myMemo;
            }
            set
            {
                if (value != this.myMemo)
                {
                    this.myMemo = value;
                    NotifyPropertyChanged();
                };
            }
        }

        public DateTime Date
        {
            get
            {
                return myDate;
            }
            set
            {
                if (value != this.myDate)
                {
                    this.myDate = value;
                    NotifyPropertyChanged();
                };
            }
        }

        public string Notification
        {
            get
            {
                return myNotification;
            }
            set
            {
                if (value != this.myNotification)
                {
                    this.myNotification = value;
                    NotifyPropertyChanged();
                };
            }
        }

        public List<KeyValuePair<int, string>> Reports
        {
            get
            {
                return myReports;
            }
            set
            {
                if (value != this.myReports)
                {
                    this.myReports = value;
                    NotifyPropertyChanged();
                };
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
