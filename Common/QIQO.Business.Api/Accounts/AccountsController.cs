using Microsoft.AspNetCore.Mvc;
using QIQO.Accounts.Domain;
using QIQO.Accounts.Manager;
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
        public async Task<IActionResult> Get()
        {
            // return Ok(new string[] { "Account1", "Account2" });
            return Ok(await _accountsManager.GetAccountsAsync());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return  Ok(await _accountsManager.GetAccountAsync(id));
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
        public async Task<IActionResult> Put(string id, [FromBody]AccountUpdateViewModel accountUpdateViewModel)
        {
            await _accountsManager.UpdateAccountAsync(new Account(accountUpdateViewModel.AccountType, 
                    accountUpdateViewModel.AccountName, accountUpdateViewModel.AccountDesc, accountUpdateViewModel.AccountDba, accountUpdateViewModel.AccountStartDate,
                    accountUpdateViewModel.AccountEndDate));
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _accountsManager.DeleteAccountAsync(id);
            return Ok();
        }
    }
}
