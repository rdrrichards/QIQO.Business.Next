using Dapr.Client;
using Microsoft.Extensions.Logging;
using Moq;
using QIQO.Accounts.Data;
using QIQO.Accounts.Domain;
using QIQO.Accounts.Manager;
using Xunit;

namespace QIQO.Accounts.Tests
{
    public class AccountManageUnitTests
    {
        private readonly Mock<ILogger<AccountsManager>> _mockLog;
        private readonly Mock<IAccountRepository> _accountRepository;
        private readonly Mock<IAccountEntityService> _accountEntityService;
        private readonly Mock<DaprClient> _daprClient;

        public AccountManageUnitTests()
        {
            _mockLog = new Mock<ILogger<AccountsManager>>();
            _accountRepository  = new Mock<IAccountRepository>();
            _accountEntityService = new Mock<IAccountEntityService>();
            _daprClient = new Mock<DaprClient>();

            _accountRepository.Setup(m => m.GetByCode(It.IsAny<string>(), It.IsAny<string>())).Returns(new AccountData());

            _accountEntityService.Setup(m => m.Map(It.IsAny<AccountData>())).Returns(new Account(new AccountData()));
            _accountEntityService.Setup(m => m.Map(It.IsAny<Account>())).Returns(new AccountData());
        }
        [Fact]
        public async void AccountsManager_GetAccountsAsync_IsEmpty()
        {
            var sut = new AccountsManager(_mockLog.Object, _daprClient.Object, _accountRepository.Object, _accountEntityService.Object);

            var retVal = await sut.GetAccountsAsync();

            Assert.True(retVal.Count == 0);
        }
        [Fact]
        public async void AccountsManager_GetAccountAsync_NotNull()
        {
            var sut = new AccountsManager(_mockLog.Object, _daprClient.Object, _accountRepository.Object, _accountEntityService.Object);

            var retVal = await sut.GetAccountAsync("TEST");

            Assert.NotNull(retVal);
        }
        [Fact]
        public async void AccountsManager_DeleteAccountAsync_DoesntFail()
        {
            var sut = new AccountsManager(_mockLog.Object, _daprClient.Object, _accountRepository.Object, _accountEntityService.Object);

            await sut.DeleteAccountAsync(0);

            // Assert.NotNull(retVal);
        }
        [Fact]
        public async void AccountsManager_SaveAccountAsync_DoesntFail()
        {
            var sut = new AccountsManager(_mockLog.Object, _daprClient.Object, _accountRepository.Object, _accountEntityService.Object);

            await sut.SaveAccountAsync(new Account(new AccountData()));

            // Assert.NotNull(retVal);
        }
    }
}
