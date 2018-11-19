using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Uniconta.API.DebtorCreditor;
using Uniconta.API.Plugin;
using Uniconta.ClientTools.DataModel;
using Uniconta.Common;

namespace PurchasePlugin
{
    public class Plugin : PageEventsBase
    {
        public override ErrorCodes OnInsert(UnicontaBaseEntity record)
        {
            var orderLineObject = (DebtorOrderLineClient) record;
            var itemObject = orderLineObject.InvItem;
            var vendorObject = itemObject.Creditor;
            
            // Indsæt nyt indkøbshoved 
            var pOrders = api.Query<CreditorOrderClient>().Result.ToList();
            Trace("Queried for " + pOrders.Count + " orders.");
            pOrders = pOrders.Where(po => po.RelatedOrder.Equals(orderLineObject.OrderNumber)).ToList();
            var pOrder = pOrders.FirstOrDefault();

            CreditorOrderClient purchaseOrder = null;
            if (pOrder == null)
            {
                purchaseOrder = new CreditorOrderClient
                {
                    Account = vendorObject.Account,
                    RelatedOrder = orderLineObject.OrderNumber,
                };
                purchaseOrder.SetMaster(vendorObject);
                var result1 = api.Insert(purchaseOrder).Result;
                Trace("Inserted purchase order with purchase number: " + purchaseOrder.OrderNumber + " with result: " + result1);
            }
            else
            {
                purchaseOrder = pOrder;
                Trace("Purchase order with order number " + purchaseOrder.OrderNumber + " already existed");
            }


            var fp = new FindPrices(purchaseOrder, api);
            fp.UseCustomerPrices = true;
            fp.loadPriceList();

            // Indsæt nyt indkøbslinje
            var purchaseOrderLine = new CreditorOrderLineClient
            {
                Item = itemObject.Item,
                Qty = orderLineObject.Qty,
            };
            fp.SetPriceFromItem(purchaseOrderLine, itemObject);
            purchaseOrderLine.SetMaster(purchaseOrder);
            var result2 = api.Insert(purchaseOrderLine);

            MessageBox.Show("lines have been added to purchase order: " + purchaseOrder.OrderNumber, "My Caption", MessageBoxButton.OK, MessageBoxImage.Information);

            Trace("User: " + api.session.User._Name);

            return base.OnInsert(record);
        }
    }
}
