﻿using ExpenseTracking.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ExpenseTracking.UI.Desktop
{
    /// <summary>
    /// Interaction logic for ListByDate.xaml
    /// </summary>
    public partial class OrderedByDate : Window
    {
        public OrderedByDate()
        {
            InitializeComponent();
            this.dgListByDate.ItemsSource = new Reports("2016.sqlite").OrderedByDate();
        }

    }
}
