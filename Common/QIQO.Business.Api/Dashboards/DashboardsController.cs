using Microsoft.AspNetCore.Mvc;
using QIQO.Invoices.Manager;
using QIQO.Orders.Manager;
using System.Threading.Tasks;

namespace QIQO.Business.Api.Dashboards
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class DashboardsController : Controller
    {
        private readonly IInvoicesManager _invoicesManager;
        private readonly IOrdersManager _orderManager;

        public DashboardsController(IInvoicesManager invoicesManager, IOrdersManager orderManager)
        {
            _invoicesManager = invoicesManager;
            _orderManager = orderManager;
        }
        [HttpGet("{companyKey}")]
        public async Task<IActionResult> Get(int companyKey)
        {
            var openInvoices = await _invoicesManager.GetOpenInvoicesAsync(companyKey);
            var openOrders = await _orderManager.GetOpenOrdersAsync(companyKey);
            var openInvoiceCount = openInvoices.Count;
            var openOrderCount = openOrders.Count;

            return Ok(new { OpenInvoiceCount = openInvoiceCount, OpenOrderCOunt = openOrderCount });
        }
    }
}
