using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniconta.API.Plugin;
using Uniconta.API.Service;
using Uniconta.API.System;
using Uniconta.ClientTools.DataModel;
using Uniconta.Common;

namespace JournalLoader
{
    public class JournalLoaderPlugin : IPluginBase
    {
        private string error;

        public string Name => "Journal Loader Plugin";

        public CrudAPI Crud { get; private set; }

        public event EventHandler OnExecute;

        public ErrorCodes Execute(UnicontaBaseEntity master, UnicontaBaseEntity currentRow, IEnumerable<UnicontaBaseEntity> source, string command, string args)
        {
            // TODO: Change Path
            using (TextFieldParser parser = new TextFieldParser(@"SOME PATH"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                // TODO: Get the correct Journal/Master
                var journal = Crud.Query<GLDailyJournalClient>().Result.First();

                var newJournalLines = new List<GLDailyJournalLineClient>();
                while (!parser.EndOfData)
                {
                    //Process row
                    string[] fields = parser.ReadFields();
                    foreach (string field in fields)
                    {
                        var journalLine = new GLDailyJournalLineClient
                        {
                            // TODO: Insert properties from fields[]
                        };
                        journalLine.SetMaster(journal);
                        newJournalLines.Add(journalLine);
                    }
                }

                // Done parsing file. Insert new journal lines.
                var result = Crud.Insert(newJournalLines).Result;
                if (result != ErrorCodes.Succes)
                {
                    // TODO: Do Error Handling.
                    return result;
                }
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
