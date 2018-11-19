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
using Uniconta.API.System;
using Uniconta.ClientTools.DataModel;

namespace Case6.Unsolved
{
    /// <summary>
    /// Interaction logic for ContentWindow.xaml
    /// </summary>
    public partial class ContentWindow : UserControl
    {
        public List<InvItemClient> Items { get; set; } = new List<InvItemClient>();
        public string SelectedCount { get; set; } = "";
        private CrudAPI CrudAPI { get; set; }

        public ContentWindow(CrudAPI api)
        {
            InitializeComponent();
            ItemList.ItemsSource = Items;
            ItemList.DisplayMemberPath = "Name";

            // TODO: Fill Items and 
        }

        private void ItemList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentlySelectedItem = (InvItemClient) ItemList.SelectedItem;
            // TODO: Figure out how many sales orders contain the currently selected item.
            CountLabel.Content = SelectedCount;
        }
    }
}
