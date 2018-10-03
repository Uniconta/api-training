using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Uniconta.API.Plugin;
using Uniconta.API.Service;
using Uniconta.API.System;
using Uniconta.Common;

namespace Case5.Unsolved
{
    public class ReadOrder : IPluginBase
    {
        public string Name => "";
        private string error;
        private CrudAPI crudAPI;

        public event EventHandler OnExecute;

        public ErrorCodes Execute(UnicontaBaseEntity master, UnicontaBaseEntity currentRow, IEnumerable<UnicontaBaseEntity> source, string command, string args)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "CSV | *csv";

            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return ErrorCodes.Succes;
            }

            var lines = new List<string[]>();

            using (TextFieldParser reader = new TextFieldParser(dialog.FileName))
            {
                reader.SetDelimiters(",");
                while (!reader.EndOfData)
                {
                    var line = reader.ReadFields();
                    lines.Add(line);
                }
            }

            //TODO: Create orderlines based on "lines"

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
            crudAPI = api as CrudAPI;
        }

        public void SetMaster(List<UnicontaBaseEntity> masters)
        {
        }
    }
}
