using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Uniconta.API.Plugin;
using Uniconta.API.System;
using Uniconta.ClientTools.Controls;
using Uniconta.ClientTools.DataModel;
using Uniconta.ClientTools.Page;
using Uniconta.Common;
using Uniconta.DataModel;

namespace DisablePlugin
{
    public class Class1 : PageEventsBase
    {
        public override void Init(object page, CrudAPI api, UnicontaBaseEntity master)
        {
            base.Init(page, api, master);
            var order = master as DebtorOrderClient;
            var disableLines = order.GetUserField("DisableLines") ?? false;
            (page as GridBasePage).gridControl.Readonly = (bool) disableLines;
            if(!(bool)disableLines)
                return;

            var test = (page as GridBasePage).ribbonControl.DataContext as RibbonBase;

            var tags = getTags(new TreeRibbon {ActionName = null, Child = test.rbnlist});
            tags.AddRange(test.MenuItems.Select(mi => mi.Tag?.ToString() ?? ""));
           (page as GridBasePage).ribbonControl.DisableButtons(tags.ToArray());
        }

        private List<string> getTags(TreeRibbon ribbon)
        {
            var tags = new List<string>();

            if (ribbon.ActionName != null)
            {
                tags.Add(ribbon.ActionName);
                return tags;
            }

            if (ribbon.Child == null)
                return tags;

            foreach (var r in ribbon.Child)
            {
                tags.AddRange(getTags(r));
            }

            return tags;
        }
    }
}
