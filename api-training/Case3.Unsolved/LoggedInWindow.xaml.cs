using System;
using System.Windows;


namespace Case3.Unsolved
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
            // TODO: Program logic for adding something to Uniconta
        }
    }
}
