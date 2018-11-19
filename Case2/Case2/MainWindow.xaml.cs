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

namespace Case2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UnicontaManager.Initialize();
        }

        private async void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            var username = UsernameTextbox.Text;
            var password = PasswordTextbox.Password;

            var loggedIn = await UnicontaManager.Login(username, password);
            if (!loggedIn)
            {
                MessageBox.Show("Failed to log in.", "Error");
                return;
            }

            new LoggedInWindow().Show();
            this.Close();
        }
    }
}
