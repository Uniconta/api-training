using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniconta.API.Plugin;
using Uniconta.API.Service;
using Uniconta.Common;

namespace Case6.Unsolved
{
    public class ItemAggregate : IContentPluginBase
    {
        public string Name => "Item Aggregate Plugin";

        public event EventHandler OnExecute;

        public ErrorCodes Execute(UnicontaBaseEntity master, UnicontaBaseEntity currentRow, IEnumerable<UnicontaBaseEntity> source, string command, string args)
        {
            return ErrorCodes.Succes;
        }

        public string[] GetDependentAssembliesName()
        {
            return new string[] { };
        }

        public string GetErrorDescription()
        {
            return "";
        }

        public void Intialize()
        {
        }

        public void OnPageClose()
        {
        }

        // TODO: Implement
        public void SetAPI(BaseAPI api)
        {
            throw new NotImplementedException();
        }

        // TODO: Implement
        public void SetContent(System.Windows.Controls.ContentControl control)
        {
            throw new NotImplementedException();
        }

        public void SetMaster(List<UnicontaBaseEntity> masters)
        {
        }
    }
}
