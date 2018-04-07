using QIQO.Accounts.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace QIQO.Accounts.Manager
{
    public interface IAccountsManager
    {
        Test GetTest();
    }
    public class AccountsManager : IAccountsManager
    {
        private readonly IAccountDbContext _accountDbContext;

        public AccountsManager(IAccountDbContext accountDbContext)
        {
            _accountDbContext = accountDbContext;
        }
        public Test GetTest()
        {
            return new Test("Testing IoC");
        }
    }
}
