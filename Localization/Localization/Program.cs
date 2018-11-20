using System;
using System.Security;
using Uniconta.API.Service;
using Uniconta.Common;
using Uniconta.Common.User;
using Uniconta.ClientTools;
using System.Threading.Tasks;

namespace Localization
{
    class Program
    {
        private static UnicontaConnection _con;
        private static Session _ses;
        private static Guid _key;

        static void Main(string[] args)
        {
            // Important. You must initialize first.
            bool initialized = false;
            while (!initialized)
            {
                var err = Init().Result;
                if (err == ErrorCodes.Succes)
            }
            Translate();
        }

        static async Task<ErrorCodes> Init()
        {
            _con = new UnicontaConnection(APITarget.Live);
            _ses = new Session(_con);
            _key = new Guid("00000000-0000-0000-0000-000000000000");

            Console.Write("Username: ");
            var username = Console.ReadLine();
            Console.Write("Password: ");
            var password = GetPassword();
            Console.WriteLine();

            var login = await _ses.LoginAsync(username, password.ToString(), LoginType.API, _key);
            if (login != ErrorCodes.Succes)
            {
                Console.WriteLine("Unable to login: " + login);
                return login;
            }
            return login;
        }

        static SecureString GetPassword()
        {
            var pwd = new SecureString();
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
                        pwd.RemoveAt(pwd.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else if (i.KeyChar != '\u0000') // KeyChar == '\u0000' if the key pressed does not correspond to a printable character, e.g. F1, Pause-Break, etc
                {
                    pwd.AppendChar(i.KeyChar);
                    Console.Write("*");
                }
            }
            return pwd;
        }

        static void Translate()
        {
            while (true)
            {
                Console.Write("Word: ");
                var word = Console.ReadLine();
                Console.Write("Lang ID: ");
                var langid = Console.ReadLine();

                Language lang = new Language();
                Language.TryParse(langid, out lang);
                var loc = Uniconta.ClientTools.Localization.GetLocalization(lang);
                var translation = loc.Lookup(word);

                Console.WriteLine("Translation: " + translation);

                Console.Write("Again? y/n: ");
                var key = Console.ReadLine();
                if (key == "y")
                {
                    Console.Clear();
                    continue;
                }
                if (key == "n")
                {
                    Console.WriteLine("Bye.");
                    break;
                }
                else
                {
                    Console.WriteLine("Unable to parse key. Quitting program.");
                    break;
                }
            }

            _ses.LogOut();

        }
    }
}

