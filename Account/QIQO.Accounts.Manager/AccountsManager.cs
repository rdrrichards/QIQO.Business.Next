﻿using Microsoft.Extensions.Logging;
using QIQO.Accounts.Data;
using QIQO.Accounts.Domain;
using QIQO.MQ;
using System.Collections.Generic;
using System.Threading.Tasks;
using QIQO.Business.Core.Contracts;
using Dapr.Client;

namespace QIQO.Accounts.Manager
{
    public interface IAccountsManager
    {
        Task SaveAccountAsync(Account account);
        Task<List<Account>> GetAccountsAsync();
        Task<List<Account>> FindAccountsAsync(int companyKey, string term);
        Task<Account> GetAccountAsync(string accountCode);
        Task DeleteAccountAsync(int accountKey);
    }
    public class AccountsManager : IAccountsManager
    {
        private readonly ILogger<AccountsManager> _log;
        private readonly DaprClient _daprClient;
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountEntityService _accountEntityService;

        public AccountsManager(ILogger<AccountsManager> logger, DaprClient daprClient,
            IAccountRepository accountRepository, IAccountEntityService accountEntityService)
        {
            _log = logger;
            _daprClient = daprClient;
            _accountRepository = accountRepository;
            _accountEntityService = accountEntityService;
        }

        public Task DeleteAccountAsync(int accountKey)
        {
            // delete account here
            return Task.Run(() => _accountRepository.DeleteByID(accountKey));
        }

        public Task<List<Account>> GetAccountsAsync()
        {
            return Task.Run(() => {
                return _accountEntityService.Map(_accountRepository.GetAll());
            });
        }

        public Task<List<Account>> FindAccountsAsync(int companyKey, string term)
        {
            return Task.Run(() => {
                return _accountEntityService.Map(_accountRepository.FindAll(companyKey, term));
            });
        }

        public Task<Account> GetAccountAsync(string accountCode)
        {
            return Task.Run(() => {
                return new Account(_accountRepository.GetByCode(accountCode, string.Empty)); // _accountRepository.GetAll();
            });
        }

        public Task SaveAccountAsync(Account account)
        {
            return Task.Run(() => {
                _accountRepository.Save(_accountEntityService.Map(account));
                _daprClient.PublishEventAsync("qiqo-pubsub", "qiqo-account-save", account);
                //_mqPublisher.Send(account, "Invoice", "account.add", "account.add");
                //_mqPublisher.Send(account, "Order", "account.add", "account.add");
                // _mqPublisher.Send(account, "Invoice", "account.add", "account.add");
            });
        }
    }
}
