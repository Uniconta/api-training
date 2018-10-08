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
using Uniconta.DataModel;

namespace Case4.Unsolved
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

        /*
         *  This method creates a table and inserts it into Uniconta.
         */
        private void CreateTableBtn_Click(object sender, RoutedEventArgs e)
        {
            // Acquire CRUD API

            // Initialize table header

            // Insert table header

        }

        /*
         *  This method inserts fields into a table in Uniconta.
         */
        private void PopulateTable_Click(object sender, RoutedEventArgs e)
        {
            // Acquire CRUD API

            // Initialize new fields

            // Set master of new fields

            // Insert newFields in bulk

        }
    }
}
