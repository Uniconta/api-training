using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Grid.Native;
using Uniconta.ClientTools.Controls;
using Uniconta.DataModel;

namespace aarhusDevexpress.Models
{
    public class CustomDataGrid : GridControl
    {
        public List<GridViewModel> Data { get; set; }

        public CustomDataGrid()
        {
            View = new DevExpress.Xpf.Grid.TableView()
            {
                ShowGroupPanel = false,
                AllowEditing = false
            };
        }

        public CustomDataGrid(IDataControlOriginationElement dataControlOriginationElement)
        {
            View = new DevExpress.Xpf.Grid.TableView()
            {
                ShowGroupPanel = false,
                AllowEditing = false
            };
        }
    }
}
