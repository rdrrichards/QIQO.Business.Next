using QIQO.Accounts.Manager;
using Xunit;

namespace QIQO.Accounts.Tests
{
    public class AccountManageUnitTests
    {
        [Fact]
        public void Test1()
        {
            var sut = new Test();

            Assert.True(sut.TestName == null);
        }
        [Fact]
        public void Test2()
        {
            var sut = new Test("TEST");

            Assert.True(sut.TestName == "TEST");
        }
    }
}
