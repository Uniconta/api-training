using System;
using System.Windows;
using Uniconta.API.Service;

namespace Case1.Unsolved
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

        protected async override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }
    }
}
