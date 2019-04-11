using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniconta.API.Plugin;
using Uniconta.ClientTools.DataModel;
using Uniconta.ClientTools.Page;

namespace Case8.Unsolved
{
    public class Plugin : PageEventsBase
    {
        public override void Record_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.Record_PropertyChanged(sender, e);
            var ol = sender as DebtorOrderLineClient;
            //TODO: check conditions and set qty correctly
        }

        private double GetTotalQty()
        {
            var sum = 0.0;
            
            //TODO: Get sum of visible rows

            return sum;
        }
    }
}
