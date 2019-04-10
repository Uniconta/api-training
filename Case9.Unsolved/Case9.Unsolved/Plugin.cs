using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using Uniconta.API.DebtorCreditor;
using Uniconta.API.Plugin;
using Uniconta.API.Service;
using Uniconta.API.System;
using Uniconta.ClientTools;
using Uniconta.ClientTools.DataModel;
using Uniconta.Common;

namespace Case9.Unsolved
{
    public class Plugin : IPluginBase
    {
        private string _error = "";
        private CrudAPI _crudAPI;

        public ErrorCodes Execute(UnicontaBaseEntity master, UnicontaBaseEntity currentRow, IEnumerable<UnicontaBaseEntity> source, string command,
            string args)
        {
            var lines = GetFileContents(GetFileName());

            var order = new DebtorOrderClient();
            order.SetMaster(currentRow as DebtorClient);
            var orderResult = _crudAPI.Insert(order).Result;

            if (orderResult == ErrorCodes.Succes)
                return CreateLines(lines, order);
            else
                return orderResult;
        }

        private ErrorCodes CreateLines(List<string[]> lines, DebtorOrderClient order)
        {
            //TODO: create orderlines on order setting correct pricing using FindPrices

            ErrorCodes result = ErrorCodes.NoSucces;

            openOrderLines(order);

            return result;
        }

        private void openOrderLines(DebtorOrderClient order)
        {
            //TODO open orderlines tab
        }

        private string GetFileName()
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "CSV | *csv";

            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return null;
            }

            return dialog.FileName;
        }

        private List<string[]> GetFileContents(string path)
        {
            var lines = new List<string[]>();

            using (TextFieldParser reader = new TextFieldParser(path))
            {
                reader.SetDelimiters(",");
                while (!reader.EndOfData)
                {
                    var line = reader.ReadFields();
                    lines.Add(line);
                }
            }

            return lines.Skip(1).ToList();
        }

        public string GetErrorDescription()
        {
            return _error;
        }

        public void SetMaster(List<UnicontaBaseEntity> masters)
        {
        }

        public void SetAPI(BaseAPI api)
        {
            _crudAPI = new CrudAPI(api);
        }

        public void Intialize()
        {
        }

        public string[] GetDependentAssembliesName()
        {
            return null;
        }

        public string Name { get; }
        public event EventHandler OnExecute;
    }
}
