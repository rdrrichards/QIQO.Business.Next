using Microsoft.Extensions.Logging;
using QIQO.Accounts.Data;
using QIQO.Accounts.Domain;
using QIQO.MQ;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QIQO.Accounts.Manager
{
    public interface IAccountsManager
    {
        Task SaveAccountAsync(Account account);
        Task<List<Account>> GetAccountsAsync();
        Task<Account> GetAccountAsync(string accountCode);
        Task DeleteAccountAsync(int accountKey);
        Task UpdateAccountAsync(Account account);
    }
    public class AccountsManager : IAccountsManager
    {
        private readonly ILogger<AccountsManager> _log;
        private readonly IMQPublisher _mqPublisher;
        private readonly IAccountRepository _accountRepository;

        public AccountsManager(ILogger<AccountsManager> logger, IMQPublisher mqPublisher, IAccountRepository accountRepository)
        {
            _log = logger;
            _mqPublisher = mqPublisher;
            _accountRepository = accountRepository;
        }

        public Task DeleteAccountAsync(int accountKey)
        {
            // delete account here
            return Task.Factory.StartNew(() => _accountRepository.DeleteByID(accountKey));
        }

        public Task<List<Account>> GetAccountsAsync()
        {
            // return Ok(new string[] { "Account1", "Account2" });
            // return Task.Factory.StartNew(() => new string[] { "Account1", "Account2" });
            return Task.Factory.StartNew(() => {
                return new List<Account> { new Account(_accountRepository.GetByID(1)) }; // _accountRepository.GetAll();
            });
        }

        public Task<Account> GetAccountAsync(string accountCode)
        {
            return Task.Factory.StartNew(() => {
                return new Account(_accountRepository.GetByCode(accountCode, string.Empty)); // _accountRepository.GetAll();
            });
        }

        public Task SaveAccountAsync(Account account)
        {
            return Task.Factory.StartNew(() => {
                _mqPublisher.Send(account, "account", "account.add", "account.add");
            });
        }

        public Task UpdateAccountAsync(Account account)
        {
            return Task.Factory.StartNew(() => _accountRepository.Save(null));
        }
    }
}
