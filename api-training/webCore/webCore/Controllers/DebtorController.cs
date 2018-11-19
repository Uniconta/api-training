using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Uniconta.ClientTools.DataModel;
using Uniconta.Common;

namespace webCore.Controllers
{
    [Produces("application/json")]
    [Route("api/Debtor")]
    public class DebtorController : Controller
    {
        // GET: api/Debtor
        [HttpGet]
        public string Get()
        {
            var res = UnicontaManager.CrudAPI.Query<DebtorClient>().Result;
            return JsonConvert.SerializeObject(res.Select(d => new { account = d.Account, name = d.Name }));
        }

        // GET: api/Debtor/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(string id)
        {
            var filters = new List<PropValuePair> { PropValuePair.GenereteWhereElements("Account", id, CompareOperator.Equal) };
            var res = UnicontaManager.CrudAPI.Query<DebtorClient>(filters).Result;
            return JsonConvert.SerializeObject(res.Select(d => new { account = d.Account, name = d.Name }));
        }

        // POST: api/Debtor
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Debtor/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
