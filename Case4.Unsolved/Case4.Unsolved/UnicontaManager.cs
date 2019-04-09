using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniconta.API.Service;
using Uniconta.API.System;
using Uniconta.Common;
using Uniconta.Common.User;
using Uniconta.DataModel;

namespace Case4.Unsolved
{
    public class UnicontaManager
    {
        private static UnicontaManager _instance;

        public UnicontaConnection Connection { get; private set; }
        public Session Session { get; private set; }
        public CrudAPI CrudAPI { get; private set; }
        public Company CurrentCompany { get; private set; }
        // TODO: Insert API Key
        private static Guid APIKey { get; set; } = new Guid("00000000-0000-0000-0000-000000000000");

        private UnicontaManager() { }

        public static UnicontaManager GetInstance()
        {
            if (_instance == null) _instance = new UnicontaManager();
            return _instance;
        }

        public void Initialize()
        {
            // TODO: Initialize UnicontaManager
        }

        public async Task<bool> Login(string username, string password)
        {
            // TODO: Program login logic (You can change the return type if you'd like)
            return false;
        }

        public async Task Logout()
        {
            // TODO: Program logout logic
        }

        private async Task InitializeCompany()
        {
            // TODO: Program logic for intializing current company
            // Hint: Session has a property called DefaultCompany, which is initialized on login if the user has set a default company.
        }

    }
}