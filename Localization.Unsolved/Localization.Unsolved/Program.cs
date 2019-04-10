using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniconta.API.Service;
using Uniconta.Common;
using Uniconta.Common.User;

namespace Localization.Unsolved
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();
        }

        static async Task MainAsync()
        {
            // TODO: Change key
            var key = new Guid("00000000-0000-0000-0000-00000000000");

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

            // TODO: Create a localization and make a lookup

            // TODO: Override a label and look it up

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
