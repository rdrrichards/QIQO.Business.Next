using Dapr.Client;
using Microsoft.Extensions.Logging;
using Moq;
using QIQO.Invoices.Data;
using QIQO.Invoices.Domain;
using QIQO.Invoices.Manager;
using QIQO.MQ;
using Xunit;

namespace QIQO.Invoices.Tests
{
    public class InvoiceManagerUnitTests
    {
        private readonly Mock<ILogger<InvoicesManager>> _mockLog;
        private readonly Mock<DaprClient> _mqPublisher;
        private readonly Mock<IInvoiceRepository> _invoiceRepository;
        private readonly Mock<IInvoiceEntityService> _invoiceEntityService;

        public InvoiceManagerUnitTests()
        {
            _mockLog = new Mock<ILogger<InvoicesManager>>();
            _mqPublisher = new Mock<DaprClient>();
            _invoiceRepository = new Mock<IInvoiceRepository>();
            _invoiceEntityService = new Mock<IInvoiceEntityService>();

            _invoiceRepository.Setup(m => m.GetByCode(It.IsAny<string>(), It.IsAny<string>())).Returns(new InvoiceData());

            _invoiceEntityService.Setup(m => m.Map(It.IsAny<InvoiceData>())).Returns(new Invoice(new InvoiceData()));
            _invoiceEntityService.Setup(m => m.Map(It.IsAny<Invoice>())).Returns(new InvoiceData());
        }
        [Fact]
        public async void InvoicesManager_GetInvoicesAsync_IsEmpty()
        {
            var sut = new InvoicesManager(_mockLog.Object, _mqPublisher.Object, _invoiceRepository.Object, _invoiceEntityService.Object);

            var retVal = await sut.GetInvoicesAsync();

            Assert.True(retVal.Count == 0);
        }
        [Fact]
        public async void InvoicesManager_GetInvoiceAsync_NotNull()
        {
            var sut = new InvoicesManager(_mockLog.Object, _mqPublisher.Object, _invoiceRepository.Object, _invoiceEntityService.Object);

            var retVal = await sut.GetInvoiceAsync("TEST");

            Assert.NotNull(retVal);
        }
        [Fact]
        public async void InvoicesManager_DeleteInvoiceAsync_DoesntFail()
        {
            var sut = new InvoicesManager(_mockLog.Object, _mqPublisher.Object, _invoiceRepository.Object, _invoiceEntityService.Object);

            await sut.DeleteInvoiceAsync(0);

            // Assert.NotNull(retVal);
        }
        [Fact]
        public async void InvoicesManager_SaveInvoiceAsync_DoesntFail()
        {
            var sut = new InvoicesManager(_mockLog.Object, _mqPublisher.Object, _invoiceRepository.Object, _invoiceEntityService.Object);

            await sut.SaveInvoiceAsync(new Invoice(new InvoiceData()));

            // Assert.NotNull(retVal);
        }
    }
}
