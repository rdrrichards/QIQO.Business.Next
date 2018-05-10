using Microsoft.Extensions.Logging;
using QIQO.Accounts.Data;
using QIQO.Accounts.Domain;
using QIQO.MQ;
using System.Collections.Generic;
using System.Threading.Tasks;
using QIQO.Business.Core.Contracts;

namespace QIQO.Accounts.Manager
{
    public interface IAccountsManager
    {
        Task SaveAccountAsync(Account account);
        Task<List<Account>> GetAccountsAsync();
        Task<Account> GetAccountAsync(string accountCode);
        Task DeleteAccountAsync(int accountKey);
    }
    public class AccountsManager : IAccountsManager
    {
        private readonly ILogger<AccountsManager> _log;
        private readonly IMQPublisher _mqPublisher;
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountEntityService _accountEntityService;

        public AccountsManager(ILogger<AccountsManager> logger, IMQPublisher mqPublisher,
            IAccountRepository accountRepository, IAccountEntityService accountEntityService)
        {
            _log = logger;
            _mqPublisher = mqPublisher;
            _accountRepository = accountRepository;
            _accountEntityService = accountEntityService;
        }

        public Task DeleteAccountAsync(int accountKey)
        {
            // delete account here
            return Task.Factory.StartNew(() => _accountRepository.DeleteByID(accountKey));
        }

        public Task<List<Account>> GetAccountsAsync()
        {
            return Task.Factory.StartNew(() => {
                return _accountEntityService.Map(_accountRepository.GetAll());
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
                _accountRepository.Save(_accountEntityService.Map(account));
                _mqPublisher.Send(account, "Invoice", "account.add", "account.add");
                _mqPublisher.Send(account, "Order", "account.add", "account.add");
                // _mqPublisher.Send(account, "Invoice", "account.add", "account.add");
            });
        }
    }
}
