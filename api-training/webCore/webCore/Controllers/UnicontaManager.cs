using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uniconta.API.Service;
using Uniconta.API.System;
using Uniconta.Common;
using Uniconta.Common.User;
using Uniconta.DataModel;

namespace webCore.Controllers
{
    public static class UnicontaManager
    {
        public static UnicontaConnection Connection { get; private set; }
        public static Session Session { get; private set; }
        // TODO: Insert API Key
        private static Guid APIKey { get; set; } = new Guid("00000000-0000-0000-0000-000000000000");
        public static CrudAPI CrudAPI { get; private set; }
        public static Company CurrentCompany { get; private set; }

        public static void Initialize()
        {
            Connection = new UnicontaConnection(APITarget.Live);
            Session = new Session(Connection);
        }

        public static async Task<bool> Login(string username, string password)
        {
            // Attempt to login
            var result = await Session.LoginAsync(username, password, LoginType.API, APIKey);

            // If Login was not succesful, return false
            if (result != ErrorCodes.Succes) return false;

            // Initialize Company, and new-up CrudAPI
            await InitializeCompany();
            CrudAPI = new CrudAPI(Session, CurrentCompany);

            return true;
        }

        public static void setCompany(int cId)
        {
            CurrentCompany = Session.GetCompany(cId).Result;
            CrudAPI = new CrudAPI(Session, CurrentCompany);
        }

        public static async Task Logout()
        {
            await Session.LogOut();
        }

        private static async Task InitializeCompany()
        {
            // If Session has a default company, use DefaultComapny as CurrentCompany
            if (Session.DefaultCompany != null)
            {
                CurrentCompany = Session.DefaultCompany;
                return;
            }

            // TODO: Change Company ID 0 to your company's ID
            CurrentCompany = await Session.OpenCompany(-1, false);
        }

    }
}
