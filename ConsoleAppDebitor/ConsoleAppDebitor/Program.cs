using System;
using System.Linq;
using System.Threading.Tasks;
using Uniconta.API.DebtorCreditor;
using Uniconta.API.Service;
using Uniconta.API.System;
using Uniconta.ClientTools.DataModel;
using Uniconta.Common;
using Uniconta.Common.User;

namespace ConsoleAppDebitor
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();
        }

        static async Task MainAsync()
        {
            var key = new Guid("69a53f30-a1b0-4d79-b6ea-ba2d36e1585f");

            #region LOGIN-PROCESS
            var con = new UnicontaConnection(APITarget.Live);
            var ses = new Session(con);

            Console.Write("Username: ");
            var username = Console.ReadLine();
            Console.Write("Password: ");
            var password = GetPassword();
            Console.WriteLine();

            var login = await ses.LoginAsync(username, password, LoginType.API, key);
            if (login != ErrorCodes.Succes)
            {
                Console.WriteLine("Unable to login: " + login);
                Exit();
                return;
            }
            Console.WriteLine($"Login success: Logged in as {ses.User._Name}\n");
            #endregion

            #region SELECT-COMPANY

            Console.Write("Enter company ID: ");
            var cmpString = Console.ReadLine();
            if (!int.TryParse(cmpString, out int cmpId))
            {
                Console.WriteLine("Not a number");
                Exit();
            }

            var cmp = await ses.OpenCompany(cmpId, false);
            Console.WriteLine($"Company selected: {cmp.Name}");

            var crud = new CrudAPI(ses, cmp);

            var debtors = await crud.Query<DebtorClient>();

            Console.Write("Expression = [search] [query]");
            var expression = Console.ReadLine();
            //var command = expression.Split()[0];
            //var param = expression.Split()[1];

            //switch (command)
            //{
            //    case "search":
            //        foreach (var d in debtors.Where(d => d.Name != null && d.Name.ToLower().Contains(param)))
            //        {
            //            Console.WriteLine($"{d.Account} | {d.Name}");
            //        }
            //        break;
            //}



            //Console.Write("Enter debtor account: ");
            //var debtorAccount = Console.ReadLine();

            //var debtor = new DebtorClient { Account = debtorAccount };
            //await crud.Read(debtor);

            //Console.Write("Enter item id: ");
            //var itemId = Console.ReadLine();

            //var item = new InvItemClient { Item = itemId };
            //await crud.Read(item);

            //Console.WriteLine("Generating sales order...");

            //DebtorOrderClient order = null;
            //order = (await crud.Query<DebtorOrderClient>(debtor)).FirstOrDefault();
            //if (order == null)
            //{
            //    order = new DebtorOrderClient { };
            //    order.SetMaster(debtor);
            //    await crud.Insert(order);
            //}


            //var orderLine = new DebtorOrderLineClient
            //{
            //    Item = item.Item,
            //    Qty = 1,
            //};
            //orderLine.SetMaster(order);
            //var fp = new FindPrices(order, crud);
            //fp.UseCustomerPrices = true;
            //fp.loadPriceList();
            //fp.SetPriceFromItem(orderLine, item);

            //await crud.Insert(orderLine);

            #endregion


            var newField = new TableFieldsClient
            {
                Name = "SomeField11",
            };
            newField.SetMaster(new DebtorOrderClient());
            var res = await crud.Insert(newField);
            Console.WriteLine(res);

            Exit();
            return;
        }

        private static void Exit()
        {
            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }

        private static string GetPassword()
        {
            var pwd = "";
            while (true)
            {
                ConsoleKeyInfo i = Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (i.Key == ConsoleKey.Backspace)
                {
                    if (pwd.Length > 0)
                    {
                        pwd.Remove(pwd.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else if (i.KeyChar != '\u0000') // KeyChar == '\u0000' if the key pressed does not correspond to a printable character, e.g. F1, Pause-Break, etc
                {
                    pwd += i.KeyChar;
                    Console.Write("*");
                }
            }
            return pwd;
        }

    }
}
