using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FromXSDFile.OIOUBL.ExportImport;

namespace aarhusDevexpress.Models
{
    public class GridViewModel
    {
        public GridViewModel(bool isDebtor, string account, DateTime duedate, string name, int ordernumber, double total)
        {
            IsDebtor = isDebtor;
            Account = account;
            DeliveryDate = duedate;
            Name = name;
            OrderNumber = ordernumber;
            Total = total;
        }
        
        public string Account { get; set; }
        public string Name { get; set; }
        public double Total { get; set; }
        public int OrderNumber { get; set; }
        public DateTime DeliveryDate { get; set; }
        public bool IsDebtor { get; set; }

    }
}
