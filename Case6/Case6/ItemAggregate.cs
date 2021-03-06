﻿using System;
using System.Collections.Generic;
using System.Linq;
using Uniconta.API.Plugin;
using Uniconta.API.Service;
using Uniconta.API.System;
using Uniconta.ClientTools.DataModel;
using Uniconta.Common;

namespace Case6
{
    public class ItemAggregate : IContentPluginBase
    {
        public string Name => "";
        private string error;
        private CrudAPI crudAPI;
        private ContentWindow content;

        public event EventHandler OnExecute;

        public ErrorCodes Execute(UnicontaBaseEntity master, UnicontaBaseEntity currentRow, IEnumerable<UnicontaBaseEntity> source, string command, string args)
        {
            return ErrorCodes.Succes;
        }

        public string[] GetDependentAssembliesName()
        {
            return new string[] { };
        }

        public string GetErrorDescription()
        {
            return error;
        }

        public void Intialize()
        {
        }

        public void SetAPI(BaseAPI api)
        {
            crudAPI = api as CrudAPI;
        }

        public void SetMaster(List<UnicontaBaseEntity> masters)
        {
        }

        public void SetContent(System.Windows.Controls.ContentControl control)
        {
            this.content = new ContentWindow(crudAPI);
            control.Content = this.content;
        }

        public void OnPageClose()
        {
        }
    }
}
