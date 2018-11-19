using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniconta.API.Plugin;
using Uniconta.Common;

namespace Case7.Unsolved
{
    public class PageEvents : PageEventsBase
    {
        public override ErrorCodes OnUpdate(UnicontaBaseEntity record, UnicontaBaseEntity original)
        {
            //TODO: save the original object in the database with a different item number, keeping them both.
            return base.OnUpdate(record, original);
        }
    }
}
