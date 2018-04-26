using Microsoft.Extensions.Logging;
using Moq;
using QIQO.Accounts.Data;
using QIQO.Accounts.Manager;
using QIQO.MQ;
using Xunit;

namespace QIQO.Accounts.Tests
{
    public class AccountManageUnitTests
    {
        private readonly Mock<ILogger<AccountsManager>> _mockLog;
        private readonly Mock<IMQPublisher> _mqPublisher;
        private readonly Mock<IAccountRepository> _accountRepository;
        private readonly Mock<IAccountEntityService> _accountEntityService;

        public AccountManageUnitTests()
        {
            _mockLog = new Mock<ILogger<AccountsManager>>();
            _mqPublisher = new Mock<IMQPublisher>();
            _accountRepository  = new Mock<IAccountRepository>();
            _accountEntityService = new Mock<IAccountEntityService>();
        }
        [Fact]
        public async void AccountsManager_GetAccountsAsync_IsEmpty()
        {
            var sut = new AccountsManager(_mockLog.Object, _mqPublisher.Object, _accountRepository.Object, _accountEntityService.Object);

            var retVal = await sut.GetAccountsAsync();

            Assert.True(retVal.Count == 0);
        }
        [Fact]
        public void Test2()
        {
            //var sut = new Test("TEST");
            //Assert.True(sut.TestName == "TEST");
        }
    }
}
