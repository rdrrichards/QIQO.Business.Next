using Microsoft.AspNetCore.Mvc;
using QIQO.Accounts.Domain;
using QIQO.Accounts.Manager;
using System.Threading.Tasks;

namespace QIQO.Business.Api.Accounts
{
    /// <summary>
    /// Account management controller
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IAccountsManager _accountsManager;
        /// <summary>
        /// Controller entry point
        /// </summary>
        /// <param name="accountsManager"></param>
        public AccountsController(IAccountsManager accountsManager)
        {
            _accountsManager = accountsManager;
        }
        /// <summary>
        /// This gets a list of accounts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // return Ok(new string[] { "Account1", "Account2" });
            return Ok(await _accountsManager.GetAccountsAsync());
        }

        // GET api/values/5
        /// <summary>
        /// This will retreive one account with the account id passed in
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return  Ok(await _accountsManager.GetAccountAsync(id));
        }

        // POST api/values
        /// <summary>
        /// Adds a new account
        /// </summary>
        /// <param name="accountAddViewModel"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Updates an existing account
        /// </summary>
        /// <param name="id"></param>
        /// <param name="accountUpdateViewModel"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody]AccountUpdateViewModel accountUpdateViewModel)
        {
            await _accountsManager.SaveAccountAsync(new Account(accountUpdateViewModel.AccountType, 
                    accountUpdateViewModel.AccountName, accountUpdateViewModel.AccountDesc, accountUpdateViewModel.AccountDba, accountUpdateViewModel.AccountStartDate,
                    accountUpdateViewModel.AccountEndDate));
            return Ok();
        }

        // DELETE api/values/5
        /// <summary>
        /// Deletes an existing account
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _accountsManager.DeleteAccountAsync(id);
            return Ok();
        }
    }
}
