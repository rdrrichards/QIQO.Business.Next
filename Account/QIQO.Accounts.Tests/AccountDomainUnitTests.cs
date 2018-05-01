using QIQO.Accounts.Data;
using QIQO.Accounts.Domain;
using Xunit;

namespace QIQO.Accounts.Tests
{
    public class AccountDomainUnitTests
    {
        [Fact]
        public void AccountModelTest1()
        {
            var data = new AccountData {
                AccountKey = 1,
                AccountCode = "TEST",
                AccountName = "TEST",
                AccountDesc = "TEST",
                AccountDba = "TEST",
                CompanyKey = 1,
                AccountStartDate = new System.DateTime(2018, 1, 1),
                AccountEndDate = new System.DateTime(2019, 1, 1),
                AccountTypeKey = 1,
                AuditAddDatetime = new System.DateTime(2018, 1, 1),
                AuditAddUserId = "TEST",
                AuditUpdateDatetime = new System.DateTime(2018, 1, 1),
                AuditUpdateUserId = "TEST"
            };
            var sut = new Account(data);
            Assert.True(sut.AccountKey == 1);
            Assert.True(sut.CompanyKey == 1);
            Assert.True(sut.AccountType == QIQOAccountType.Individual);
            Assert.True(sut.AccountCode == "TEST");
            Assert.True(sut.AccountName == "TEST");
            Assert.True(sut.AccountDesc == "TEST");
            Assert.True(sut.AccountDba == "TEST");
            Assert.True(sut.AddedUserID == "TEST");
            Assert.True(sut.UpdateUserID == "TEST");
            Assert.True(sut.AccountStartDate == new System.DateTime(2018, 1, 1));
            Assert.True(sut.AccountEndDate == new System.DateTime(2019, 1, 1));
            Assert.True(sut.AddedDateTime == new System.DateTime(2018, 1, 1));
            Assert.True(sut.UpdateDateTime == new System.DateTime(2018, 1, 1));

            Assert.True(sut.Comments.Count == 0);
            Assert.True(sut.Contacts.Count == 0);
            Assert.True(sut.Addresses.Count == 0);
            Assert.True(sut.FeeSchedules.Count == 0);
            Assert.True(sut.Employees.Count == 0);
            Assert.True(sut.AccountAttributes.Count == 0);
        }

        [Fact]
        public void AccountModelTest2()
        {
            var sut = new Account(1, QIQOAccountType.Individual, "TEST", "TEST", "TEST", "TEST",
                new System.DateTime(2018, 1, 1), new System.DateTime(2019, 1, 1));
            Assert.True(sut.AccountKey == 0);
            Assert.True(sut.CompanyKey == 1);
            Assert.True(sut.AccountType == QIQOAccountType.Individual);
            Assert.True(sut.AccountCode == "TEST");
            Assert.True(sut.AccountName == "TEST");
            Assert.True(sut.AccountDesc == "TEST");
            Assert.True(sut.AccountDba == "TEST");
            Assert.True(sut.AddedUserID == null);
            Assert.True(sut.UpdateUserID == null);
            Assert.True(sut.AccountStartDate == new System.DateTime(2018, 1, 1));
            Assert.True(sut.AccountEndDate == new System.DateTime(2019, 1, 1));
            Assert.True(sut.AddedDateTime != null);
            Assert.True(sut.UpdateDateTime != null);

            Assert.True(sut.Comments.Count == 0);
            Assert.True(sut.Contacts.Count == 0);
            Assert.True(sut.Addresses.Count == 0);
            Assert.True(sut.FeeSchedules.Count == 0);
            Assert.True(sut.Employees.Count == 0);
            Assert.True(sut.AccountAttributes.Count == 0);
        }
    }
}
