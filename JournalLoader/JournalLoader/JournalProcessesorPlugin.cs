using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniconta.API.Plugin;
using Uniconta.API.Service;
using Uniconta.API.System;
using Uniconta.ClientTools;
using Uniconta.ClientTools.DataModel;
using Uniconta.Common;

namespace JournalLoader
{
    public class JournalProcessesorPlugin : IPluginBase
    {
        public string Name => "Journal Processor";

        public CrudAPI Crud { get; private set; }

        public event EventHandler OnExecute;

        public ErrorCodes Execute(UnicontaBaseEntity master, UnicontaBaseEntity currentRow, IEnumerable<UnicontaBaseEntity> source, string command, string args)
        {
            var original = StreamingManager.Clone(source);
            foreach (GLDailyJournalLineClient line in source)
            {
                if (line.Text?.Contains("@1") ?? false)
                {
                    // TODO process
                    line.AccountType = "Ledger";
                    line.Account = "1000";
                }
            }
            return Crud.Update(original, source).Result;
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

        public void SetAPI(BaseAPI api)
        {
            Crud = new CrudAPI(api);
        }

        public void SetMaster(List<UnicontaBaseEntity> masters)
        {
        }
    }
}
