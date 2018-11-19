using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniconta.API.Plugin;
using Uniconta.ClientTools.DataModel;
using Uniconta.Common;

namespace Case7
{
    public class PEB : PageEventsBase
    {
        public override ErrorCodes OnUpdate(UnicontaBaseEntity record, UnicontaBaseEntity original)
        {
            var clone = StreamingManager.Clone(original);
            var baserRes =  base.OnUpdate(record, original);
            (clone as InvItemClient).Item = (clone as InvItemClient).Item + 1;
            var res = api.Insert(clone).Result;
            return baserRes;
        }
    }
}
