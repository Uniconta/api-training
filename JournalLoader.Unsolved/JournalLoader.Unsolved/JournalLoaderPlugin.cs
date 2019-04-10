using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniconta.API.GeneralLedger;
using Uniconta.API.Plugin;
using Uniconta.API.Service;
using Uniconta.API.System;
using Uniconta.ClientTools;
using Uniconta.ClientTools.DataModel;
using Uniconta.Common;

namespace JournalLoader.Unsolved
{
    public class JournalLoaderPlugin : IPluginBase
    {
        private string error;

        public string Name => "Journal Loader Plugin";

        public CrudAPI Crud { get; private set; }

        public event EventHandler OnExecute;

        public ErrorCodes Execute(UnicontaBaseEntity master, UnicontaBaseEntity currentRow, IEnumerable<UnicontaBaseEntity> source, string command, string args)
        {
            // Plugin must be installed on Control: GL_DailyJournal

            var journal = currentRow as GLDailyJournalClient;

            // TODO: Change Path
            using (TextFieldParser parser = new TextFieldParser(@"[FULL PATH TO DATA.CSV]"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                // Read the first line to get rid of header
                parser.ReadFields();

                while (!parser.EndOfData)
                {
                    //Process row
                    string[] fields = parser.ReadFields();
                    // TODO: Process fields

                }

                // TODO insert new GLDailyJournalLines


                // Post Journals
                var postingAPI = new PostingAPI(Crud);

                // TODO Post (Bogfør) newly created GLDailyJournalLines

            }
            return ErrorCodes.Succes;
        }

        public string[] GetDependentAssembliesName()
        {
            return new string[] { };
        }

        public string GetErrorDescription()
        {
            return error;
        }

        public void Intialize()
        {
        }

        public void SetAPI(BaseAPI api)
        {
            Crud = api as CrudAPI;
        }

        public void SetMaster(List<UnicontaBaseEntity> masters)
        {
        }
    }
}
