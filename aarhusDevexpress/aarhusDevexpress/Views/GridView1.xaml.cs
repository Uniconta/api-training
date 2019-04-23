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
using aarhusDevexpress.Models;
using Uniconta.API.Service;
using Uniconta.API.System;
using Uniconta.ClientTools.Controls;
using Uniconta.ClientTools.DataModel;
using Uniconta.ClientTools.Page;
using Uniconta.Common;

namespace aarhusDevexpress.Views
{
    /// <summary>
    /// Interaction logic for GridView.xaml
    /// </summary>
    public partial class GridView1 : ControlBasePage
    {
        private List<GridViewModel> _allOrders;

        public GridView1(UnicontaBaseEntity sourcedata) : base(null)
        {
            InitializeComponent();

            _allOrders = new List<GridViewModel>();
            localMenu.AddRibbonItems(CreateRibbonItems());
            localMenu.OnItemClicked += LocalMenu_OnItemClicked;

            grid.Data = GetDataForGrid().ToList();
            grid.ItemsSource = GetDataForGrid().ToList();

            DebtorCheck.IsChecked = true;
            DebtorCheck.Checked += OnChecked;
            DebtorCheck.Unchecked += OnChecked;
            CreditorCheck.IsChecked = true;
            CreditorCheck.Checked += OnChecked;
            CreditorCheck.Unchecked += OnChecked;
        }

        private void OnChecked(object sender, RoutedEventArgs e)
        {
            grid.Data = GetDataForGrid().ToList();
            var orders = new List<GridViewModel>();

            if (DebtorCheck.IsChecked.HasValue && DebtorCheck.IsChecked.Value)
                orders.AddRange(_allOrders.Where(o => o.IsDebtor));

            if(CreditorCheck.IsChecked.HasValue && CreditorCheck.IsChecked.Value)
                orders.AddRange(_allOrders.Where(o => !o.IsDebtor));

            grid.ItemsSource = orders;
        }

        private IEnumerable<GridViewModel> GetDataForGrid()
        {
            var orders = new List<GridViewModel>();
            var DebtorOrders = api.QuerySync<DebtorOrderClient>();
            var CreditorOrders = api.QuerySync<CreditorOrderClient>();
            orders.AddRange(DebtorOrders.Select(d =>
                new GridViewModel(true, d.Account, d.DueDate, d.Name, d.OrderNumber, d._OrderTotal)));

            orders.AddRange(CreditorOrders.Select(d =>
                new GridViewModel(false, d.Account, d.DueDate, d.Name, d.OrderNumber, d._OrderTotal)));

            _allOrders = orders;
            return orders;
        }

        private void LocalMenu_OnItemClicked(string ActionType)
        {

        }

        List<TreeRibbon> CreateRibbonItems()
        {

            var ribbonItems = new List<TreeRibbon>();

            var refreshRowItem = new TreeRibbon();
            refreshRowItem.ActionName = "RefreshGrid";
            refreshRowItem.Name = "Refresh";
            refreshRowItem.LargeGlyph = LargeIcon.Refresh.ToString();

            var gotoInvoiceLines = new TreeRibbon();
            gotoInvoiceLines.ActionName = "GoToInvoiceLines";
            gotoInvoiceLines.Name = "Go to invoice lines";
            gotoInvoiceLines.LargeGlyph = LargeIcon.Next.ToString();

            var exportToXML = new TreeRibbon();
            exportToXML.ActionName = "ExportToXML";
            exportToXML.Name = "Export to XML";
            exportToXML.LargeGlyph = LargeIcon.Export.ToString();

            ribbonItems.Add(refreshRowItem);
            ribbonItems.Add(gotoInvoiceLines);
            ribbonItems.Add(exportToXML);
            return ribbonItems;
        }
    }
}
