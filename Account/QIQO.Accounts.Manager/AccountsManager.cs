using QIQO.Accounts.Data;
using QIQO.Business.Core.ServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace QIQO.Accounts.Manager
{
    public interface IAccountsManager
    {
        Test GetTest();
        void SaveTest(Test test);
    }
    public class AccountsManager : IAccountsManager
    {
        private readonly IAccountDbContext _accountDbContext;
        private readonly IMQPublisher _mqPublisher;

        public AccountsManager(IAccountDbContext accountDbContext, IMQPublisher mqPublisher)
        {
            _accountDbContext = accountDbContext;
            _mqPublisher = mqPublisher;
        }
        public Test GetTest()
        {
            return new Test("Testing IoC");
        }

        public void SaveTest(Test test)
        {
            _mqPublisher.Send(test, "payment.card");
            _mqPublisher.Send(test, "payment.purchaseorder");
        }
    }
}
