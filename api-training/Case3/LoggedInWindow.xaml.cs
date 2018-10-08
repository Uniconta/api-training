﻿using System;
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

namespace Case3
{
    /// <summary>
    /// Interaction logic for LoggedInWindow.xaml
    /// </summary>
    public partial class LoggedInWindow : Window
    {
        public LoggedInWindow()
        {
            InitializeComponent();
        }

        protected override async void OnClosed(EventArgs e)
        {
            await UnicontaManager.Logout();
            base.OnClosed(e);
        }

        private void PopulateBtn_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Program Population logic
        }
    }
}