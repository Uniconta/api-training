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
using Uniconta.ClientTools.DataModel;
using Uniconta.Common;

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
            await UnicontaManager.GetInstance().Logout();
            base.OnClosed(e);
        }

        private async void PopulateBtn_Click(object sender, RoutedEventArgs e)
        {
            // Acquire CRUD API
            var crud = UnicontaManager.GetInstance().CrudAPI;

            // Initialize Item
            var myItem = new InvItemClient
            {
                Item = "109",
                Name = "Toothbrush",
                CostPrice = 29.95,
                SalesPrice1 = 100.00,
            };

            // Insert Item
            var result = await crud.Insert(myItem);
            if (result != ErrorCodes.Succes)
            {
                MessageBox.Show("Unable to insert item. Error: " + result.ToString(), "Error");
                return;
            }

            MessageBox.Show("Succesfully inserted item: " + myItem.Item + ", name: " + myItem.Name + "into Uniconta", "Succes");

        }
    }
}
