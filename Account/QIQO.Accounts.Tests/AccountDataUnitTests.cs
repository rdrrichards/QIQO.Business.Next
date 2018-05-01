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
        private readonly Mock<IAccountMap> _accountMapper;
        private readonly Mock<ILogger<AccountData>> _accountDataLog;

        public AccountDataUnitTests()
        {
            _mockLog = new Mock<ILogger<AccountRepository>>();
            _accountDbContext = new Mock<IAccountDbContext>();
            _accountMapper = new Mock<IAccountMap>();
            _accountDataLog = new Mock<ILogger<AccountData>>();
        }
        [Fact]
        public void AccountDeleteTest()
        {

            var sut = new AccountRepository(_accountDbContext.Object, _accountMapper.Object, _accountDataLog.Object);

            sut.Delete(new AccountData { AccountCode = "TEST", AccountKey = 1 } );
        }
        [Fact]
        public void AccountDeleteByCodeTest()
        {
            var sut = new AccountRepository(_accountDbContext.Object, _accountMapper.Object, _accountDataLog.Object);

            sut.DeleteByCode("TEST");
        }
        [Fact]
        public void AccountDeleteByIDTest()
        {
            var sut = new AccountRepository(_accountDbContext.Object, _accountMapper.Object, _accountDataLog.Object);

            sut.DeleteByID(0);
        }
        [Fact]
        public void AccountInsertTest()
        {
            var sut = new AccountRepository(_accountDbContext.Object, _accountMapper.Object, _accountDataLog.Object);

            sut.Insert(new AccountData { AccountCode = "TEST", AccountKey = 1 });
        }
        [Fact]
        public void AccountSaveTest()
        {
            var sut = new AccountRepository(_accountDbContext.Object, _accountMapper.Object, _accountDataLog.Object);

            sut.Save(new AccountData { AccountCode = "TEST", AccountKey = 1 });
        }
    }
}
