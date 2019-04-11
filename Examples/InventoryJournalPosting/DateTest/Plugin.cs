using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Uniconta.API.Inventory;
using Uniconta.API.Plugin;
using Uniconta.API.Service;
using Uniconta.API.System;
using Uniconta.ClientTools.DataModel;
using Uniconta.Common;
using Uniconta.DataModel;

namespace DateTest
{
    public class Plugin : IPluginBase
    {
        private string _error;
        private PostingAPI _postingAPI;
        private CrudAPI _crudApi;

        public string GetErrorDescription()
        {
            return _error;
        }

        public ErrorCodes Execute(UnicontaBaseEntity master, UnicontaBaseEntity currentRow, IEnumerable<UnicontaBaseEntity> source, string command,
            string args)
        {
            var journal = currentRow as InvJournalClient;
            var qty = GetQty();

            var line = new InvJournalLineClient();
            line.Qty = qty.Item1;
            line.Item = qty.Item2;

            line.SetMaster(journal);
            if (_crudApi.Insert(line).Result == ErrorCodes.Succes)
            {
                var postingResult = _postingAPI.PostJournal(journal, DateTime.Now, "", "", "", 0, false,
                    new GLTransClient(), 0).Result;
                return postingResult.Err;
            }

            return ErrorCodes.NoSucces;
        }

        public void SetMaster(List<UnicontaBaseEntity> masters)
        {}

        public void SetAPI(BaseAPI api)
        {
            _crudApi = new CrudAPI(api);
            _postingAPI = new PostingAPI(api);
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

        private Tuple<double, string> GetQty()
        {
            var text = "input quantity";
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen
            };

            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };

            var comboBox = new ComboBox();
            comboBox.DataSource = _crudApi.QuerySync<InvItemClient>().Select(i => i.Item).ToList();

            Button confirmation = new Button()
                { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };

            confirmation.Click += (sender, e) => {
                prompt.Close();
            };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(comboBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? Tuple.Create(double.Parse(textBox.Text), comboBox.Text) : Tuple.Create(0.0, comboBox.Text);
        }

    }
}
