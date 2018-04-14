using Microsoft.Extensions.Logging;
using QIQO.Accounts.Data;
using QIQO.Accounts.Domain;
using QIQO.MQ;
using System.Threading.Tasks;

namespace QIQO.Accounts.Manager
{
    public interface IAccountsManager
    {
        Test GetTest();
        // void SaveTest(Test test);
        Task SaveAccountAsync(Account account);
    }
    public class AccountsManager : IAccountsManager
    {
        private readonly ILogger<AccountsManager> _log;
        private readonly IMQPublisher _mqPublisher;

        public AccountsManager(ILogger<AccountsManager> logger, IMQPublisher mqPublisher)
        {
            _log = logger;
            _mqPublisher = mqPublisher;
        }
        public Test GetTest()
        {
            return new Test("Testing IoC");
        }

        //public void SaveTest(Test test)
        //{
        //    _mqPublisher.Send(test, "payment.card");
        //    _mqPublisher.Send(test, "payment.purchaseorder");
        //}

        public Task SaveAccountAsync(Account account)
        {
            return Task.Factory.StartNew(() => {
                _mqPublisher.Send(account, "account", "account.add", "account.add");
            });
        }
    }
}
