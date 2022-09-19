using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using QIQO.Accounts.Data;
using Xunit;

namespace QIQO.Accounts.Tests
{
    public class AccountDataIntegrationTests
    {
        private readonly Mock<ILogger<AccountDbContext>> _mockLog;
        // private readonly Mock<IConfiguration> _configuration;
        private readonly IAccountDbContext _accountDbContext;
        private readonly IAccountMap _accountMapper;
        private readonly Mock<ILogger<AccountData>> _accountDataLog;

        public AccountDataIntegrationTests()
        {
            _mockLog = new Mock<ILogger<AccountDbContext>>();
            // _configuration = new Mock<IConfiguration>();
            // _configuration.Setup(m => m["ConnectionStrings:AccountManagement"]).Returns();
            _accountDbContext = new AccountDbContext(@"Data Source=RDRRL8\D1;User ID=businessuser;Password=businessuser512;Database=AccountManagement;Application Name=QIQOBusinessAccountsIntegrationTester");
            _accountMapper = new AccountMap();
            _accountDataLog = new Mock<ILogger<AccountData>>();
        }
        //[Fact]
        //public void AccountDeleteIntegrationTest()
        //{

        //    var sut = new AccountRepository(_accountDbContext, _accountMapper, _accountDataLog.Object);

        //    sut.Delete(new AccountData { AccountCode = "TEST10", AccountKey = 24 } );
        //}
        //[Fact]
        //public void AccountDeleteByCodeIntegrationTest()
        //{
        //    var sut = new AccountRepository(_accountDbContext, _accountMapper, _accountDataLog.Object);

        //    sut.DeleteByCode("TEST10");
        //}
        //[Fact]
        //public void AccountDeleteByIDIntegrationTest()
        //{
        //    var sut = new AccountRepository(_accountDbContext, _accountMapper, _accountDataLog.Object);

        //    sut.DeleteByID(24);
        //}
        //[Fact]
        //public void AccountInsertIntegrationTest()
        //{
        //    var sut = new AccountRepository(_accountDbContext, _accountMapper, _accountDataLog.Object);

        //    sut.Insert(new AccountData { AccountCode = "TEST10", AccountKey = 24 });
        //}
        [Fact]
        public void AccountDataAccessIntegrationTest()
        {
            var sut = new AccountRepository(_accountDbContext, _accountMapper, _accountDataLog.Object);
            var account = new AccountData
            {
                AccountCode = "TEST10",
                //AccountKey = 24,
                AccountStartDate = System.DateTime.Now,
                AccountEndDate = System.DateTime.Now.AddYears(1),
                AccountDba = "TEST10",
                AccountDesc = "TEST10",
                CompanyKey = 2,
                AccountTypeKey = 3,
                AccountName = "TEST10"
            };
            sut.Insert(account);
            account = sut.GetByCode("TEST10", "TEST");
            sut.Save(account);
            sut.Delete(account);
            //sut.Insert(account);
        }
    }
}
