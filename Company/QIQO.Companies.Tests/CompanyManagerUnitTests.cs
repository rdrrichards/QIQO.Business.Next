using Microsoft.Extensions.Logging;
using Moq;
using QIQO.Accounts.Manager;
using QIQO.Companies.Data;
using QIQO.Companies.Domain;
using QIQO.Companies.Manager;
using QIQO.MQ;
using Xunit;

namespace QIQO.Companies.Tests
{
    public class CompanyManagerUnitTests
    {
        private readonly Mock<ILogger<CompaniesManager>> _mockLog;
        private readonly Mock<IMQPublisher> _mqPublisher;
        private readonly Mock<ICompanyRepository> _companyRepository;
        private readonly Mock<ICompanyEntityService> _companyEntityService;

        public CompanyManagerUnitTests()
        {
            _mockLog = new Mock<ILogger<CompaniesManager>>();
            _mqPublisher = new Mock<IMQPublisher>();
            _companyRepository = new Mock<ICompanyRepository>();
            _companyEntityService = new Mock<ICompanyEntityService>();

            _companyRepository.Setup(m => m.GetByCode(It.IsAny<string>(), It.IsAny<string>())).Returns(new CompanyData());

            _companyEntityService.Setup(m => m.Map(It.IsAny<CompanyData>())).Returns(new Company(new CompanyData()));
            _companyEntityService.Setup(m => m.Map(It.IsAny<Company>())).Returns(new CompanyData());
        }
        [Fact]
        public async void CompaniesManager_GetCompaniesAsync_IsEmpty()
        {
            var sut = new CompaniesManager(_mockLog.Object, _mqPublisher.Object, _companyRepository.Object, _companyEntityService.Object);

            var retVal = await sut.GetCompaniesAsync();

            Assert.True(retVal.Count == 0);
        }
        [Fact]
        public async void CompaniesManager_GetCompanyAsync_NotNull()
        {
            var sut = new CompaniesManager(_mockLog.Object, _mqPublisher.Object, _companyRepository.Object, _companyEntityService.Object);

            var retVal = await sut.GetCompanyAsync("TEST");

            Assert.NotNull(retVal);
        }
        [Fact]
        public async void CompaniesManager_DeleteCompanyAsync_DoesntFail()
        {
            var sut = new CompaniesManager(_mockLog.Object, _mqPublisher.Object, _companyRepository.Object, _companyEntityService.Object);

            await sut.DeleteCompanyAsync(0);

            // Assert.NotNull(retVal);
        }
        [Fact]
        public async void CompaniesManager_SaveCompanyAsync_DoesntFail()
        {
            var sut = new CompaniesManager(_mockLog.Object, _mqPublisher.Object, _companyRepository.Object, _companyEntityService.Object);

            await sut.SaveCompanyAsync(new Company(new CompanyData()));

            // Assert.NotNull(retVal);
        }
        [Fact]
        public async void CompaniesManager_UpdateCompanyAsync_DoesntFail()
        {
            var sut = new CompaniesManager(_mockLog.Object, _mqPublisher.Object, _companyRepository.Object, _companyEntityService.Object);

            await sut.UpdateCompanyAsync(new Company(new CompanyData()));

            // Assert.NotNull(retVal);
        }
    }
}
