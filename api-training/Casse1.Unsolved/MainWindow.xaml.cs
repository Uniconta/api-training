using System;
using System.Windows;
using Uniconta.API.Service;
using Uniconta.Common;
using Uniconta.Common.User;

namespace Case1.Unsolved
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // TODO: Insert API Key
        private Guid APIKey { get; } = new Guid("00000000-0000-0000-0000-000000000000");

        public MainWindow()
        {
            // TODO: Initialize Connection and Session
            InitializeComponent();
        }

        private async void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve username and password from input fields
            var userName = UsernameTextbox.Text;
            var passWord = PasswordTextbox.Password;

            // TODO: Login

            // Succesfully logged in. Navigate to next window
            new LoggedInWindow().Show();
            this.Close();

        }
    }
}
