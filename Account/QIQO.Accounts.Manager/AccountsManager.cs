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
        void PullTest();
    }
    public class AccountsManager : IAccountsManager
    {
        private readonly IAccountDbContext _accountDbContext;
        private readonly IMQPublisher _mqPublisher;
        private readonly IMQConsumer _mqConsumer;

        public AccountsManager(IAccountDbContext accountDbContext, IMQPublisher mqPublisher, IMQConsumer mqConsumer)
        {
            _accountDbContext = accountDbContext;
            _mqPublisher = mqPublisher;
            _mqConsumer = mqConsumer;
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

        public void PullTest()
        {
            _mqConsumer.Pull("payment.card");
            // _mqConsumer.Pull("payment.purchaseorder");
        }
    }
}
