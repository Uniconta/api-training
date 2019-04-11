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

namespace Case9
{
    public class Plugin : IPluginBase
    {
        private string _error = "";
        private CrudAPI _crudAPI;

        public ErrorCodes Execute(UnicontaBaseEntity master, UnicontaBaseEntity currentRow, IEnumerable<UnicontaBaseEntity> source, string command,
            string args)
        {
            var lines = GetFileContents(GetFileName());

            return CreateLines(lines, currentRow as DebtorClient);
        }

        private ErrorCodes CreateLines(List<string[]> lines, DebtorClient debtorClient)
        {
            var ols = new List<DebtorOrderLineClient>();
            var items = _crudAPI.Query<InvItemClient>().Result;

            var order = new DebtorOrderClient();
            order.SetMaster(debtorClient);
            var orderres = _crudAPI.Insert(order).Result;
            
            foreach (string[] s in lines)
            {
                var item = items.First(i => i.Item == s[1]);

                var fp = new FindPrices(order, _crudAPI);
                fp.UseCustomerPrices = true;
                fp.loadPriceList();

                var ol = new DebtorOrderLineClient
                {
                    Qty = double.Parse(s[2]),
                    Item = item.Item,
                    //Date = DateTime.Parse(s[3]),
                };
                ol.SetMaster(order);

                fp.SetPriceFromItem(ol, item);

                ols.Add(ol);
            }

            var result = _crudAPI.Insert(ols).Result;
            if(result==ErrorCodes.Succes)
                openOrderLines(order);

            return result;
        }

        private void openOrderLines(DebtorOrderClient order)
        {
            UnicontaTabs.OpenTab(UnicontaTabs.DebtorOrdersLine, new object[] { order });
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
