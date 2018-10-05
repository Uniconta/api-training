using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniconta.API.Service;
using Uniconta.Common;
using Uniconta.Common.User;

namespace Case2
{
    public static class UnicontaManager
    {
        public static UnicontaConnection Connection { get; private set; }
        public static Session Session { get; private set; }
        // TODO: Insert API Key
        private static Guid APIKey { get; set; } = new Guid("00000000-0000-0000-0000-000000000000");

        public static void Initialize()
        {
            Connection = new UnicontaConnection(APITarget.Live);
            Session = new Session(Connection);
        }

        public static async Task<bool> Login(string username, string password)
        {
            var result = await Session.LoginAsync(username, password, LoginType.API, APIKey);
            if (result != ErrorCodes.Succes) return false;
            return true;
        }

        public static async Task Logout()
        {
            await Session.LogOut();
        }

    }
}
