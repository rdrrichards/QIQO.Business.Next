using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace QIQO.Business.Api.Accounts
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Account1", "Account2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Account";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            // throw new System.Exception("All hell broke loose!!!");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
