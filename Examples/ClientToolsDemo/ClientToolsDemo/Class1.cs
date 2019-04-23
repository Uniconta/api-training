using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniconta.API.Plugin;
using Uniconta.API.System;
using Uniconta.ClientTools.Controls;
using Uniconta.ClientTools.Page;
using Uniconta.Common;

namespace ClientToolsDemo
{
    public class Class1 : PageEventsBase
    {
        public override void Init(object page, CrudAPI api, UnicontaBaseEntity master)
        {
            base.Init(page, api, master);
        }

        public override void SelectedRowChanged(SelectedItemChangedArgs e)
        {
            base.SelectedRowChanged(e);
        }
    }
}
