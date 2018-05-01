using Microsoft.Extensions.Logging;
using Moq;
using QIQO.Accounts.Data;
using Xunit;

namespace QIQO.Accounts.Tests
{
    public class AccountDataUnitTests
    {
        private readonly Mock<ILogger<AccountRepository>> _mockLog;
        private readonly Mock<IAccountDbContext> _accountDbContext;

        public AccountDataUnitTests()
        {
            _mockLog = new Mock<ILogger<AccountRepository>>();
            _accountDbContext = new Mock<IAccountDbContext>();
        }
        [Fact]
        public void AccountDeleteTest()
        {
            var _accountMapper = new Mock<IAccountMap>();
            var _accountDataLog = new Mock<ILogger<AccountData>>();

            var sut = new AccountRepository(_accountDbContext.Object, _accountMapper.Object, _accountDataLog.Object);

            sut.Delete(new AccountData { AccountCode = "TEST", AccountKey = 1 } );
        }
    }
}
