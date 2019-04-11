using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniconta.API.Plugin;
using Uniconta.ClientTools.Controls;
using Uniconta.ClientTools.DataModel;
using Uniconta.ClientTools.Page;

namespace Case8
{
    public class Plugin : PageEventsBase
    {
        public override void Record_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.Record_PropertyChanged(sender, e);
            var ol = sender as DebtorOrderLineClient;
            if (e.PropertyName == "Text" && ol.Text == "Fragt")
            {
                ol.Qty = GetTotalQty();
            }
        }

        private double GetTotalQty()
        {
            var sum = 0.0;
            foreach (var line in (page as GridBasePage).gridControl.GetVisibleRows())
            {
                sum += (line as DebtorOrderLineClient)?.Qty ?? 0.0;
            }

            return sum;
        }
    }
}
