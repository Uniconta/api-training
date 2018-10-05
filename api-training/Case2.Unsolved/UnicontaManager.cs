using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniconta.API.Service;

namespace Case2.Unsolved
{
    public static class UnicontaManager
    {
        public static UnicontaConnection Connection { get; private set; }
        public static Session Session { get; private set; }
        // TODO: Insert API Key
        private static Guid APIKey { get; set; } = new Guid("00000000-0000-0000-0000-000000000000");

        public static void Initialize()
        {
            // TODO: Initialize UnicontaManager
        }

        public static async Task<bool> Login(string username, string password)
        {
            // TODO: Program login logic (You can change the return type if you'd like)
            return false;
        }

        public static async Task Logout()
        {
            // TODO: Program logout logic
        }

    }
}
