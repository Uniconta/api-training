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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Uniconta.API.Service;
using Uniconta.Common;
using Uniconta.Common.User;

namespace Case1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UnicontaConnection _connection { get; set; }
        private Session _session { get; set; }
        // TODO: Insert API Key
        private Guid APIKey { get; } = new Guid("00000000-0000-0000-0000-000000000000");

        public MainWindow()
        {
            _connection = new UnicontaConnection(APITarget.Live);
            _session = new Session(_connection);
            InitializeComponent();
        }

        private async void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve username and password from input fields
            var userName = UsernameTextbox.Text;
            var passWord = PasswordTextbox.Password;

            // Check if username or password is empty to save the API of doing it
            if (userName.Equals("") || passWord.Equals(""))
            {
                MessageBox.Show("Username or Password is Empty.", "Warning");
                return;
            }

            // Attempt to login the session
            var loginResult = await _session.LoginAsync(userName, passWord, LoginType.API, APIKey);
            if (loginResult != ErrorCodes.Succes)
            {
                MessageBox.Show("Unable to Login. Error: " + loginResult.ToString());
                return;
            }

            // Succesfully logged in. Navigate to next window
            new LoggedInWindow(_session).Show();
            this.Close();

        }
    }
}
