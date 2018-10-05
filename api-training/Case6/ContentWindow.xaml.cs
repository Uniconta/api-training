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

namespace Case6
{
    /// <summary>
    /// Interaction logic for ContentWindow.xaml
    /// </summary>
    public partial class ContentWindow : UserControl
    {
        public List<InvItemClient> Items { get; set; }
        public int SelectedCount { get; set; }
        private CrudAPI CrudAPI { get; set; }
        private DebtorOrderLineClient[] AllOrderLines { get; set; }

        public ContentWindow(List<InvItemClient> items, CrudAPI api)
        {
            CrudAPI = api; // Initialize CrudAPI
            Items = items; // Initialize Item
            AllOrderLines = CrudAPI.Query<DebtorOrderLineClient>().Result; // Query for all Order Lines
            InitializeComponent();
        }

        private void ItemList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currItem = (InvItemClient)sender;
            SelectedCount = AllOrderLines.Where(o => o.InvItem.Item.Equals(currItem.Item)).Count();
        }
    }
}
