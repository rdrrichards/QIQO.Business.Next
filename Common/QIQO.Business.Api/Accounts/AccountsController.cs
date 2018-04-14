using Microsoft.AspNetCore.Mvc;
using QIQO.Accounts.Domain;
using QIQO.Accounts.Manager;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QIQO.Business.Api.Accounts
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IAccountsManager _accountsManager;

        public AccountsController(IAccountsManager accountsManager)
        {
            _accountsManager = accountsManager;
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Account1", "Account2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_accountsManager.GetTest());
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AccountAddViewModel accountAddViewModel)
        {
            if (ModelState.IsValid)
            {
                await _accountsManager.SaveAccountAsync(new Account(accountAddViewModel.CompanyKey, accountAddViewModel.AccountType, accountAddViewModel.AccountCode,
                    accountAddViewModel.AccountName, accountAddViewModel.AccountDesc, accountAddViewModel.AccountDba, accountAddViewModel.AccountStartDate, accountAddViewModel.AccountEndDate));
                return Ok();
            }
            else
            {
                return BadRequest();
            }
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
            // _accountsManager.PullTest();
        }
    }
}
