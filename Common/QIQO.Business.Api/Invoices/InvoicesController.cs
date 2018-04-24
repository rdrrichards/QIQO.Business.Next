using Microsoft.AspNetCore.Mvc;
using QIQO.Invoices.Domain;
using QIQO.Invoices.Manager;
using System.Threading.Tasks;

namespace QIQO.Business.Api.Invoices
{
    [Route("api/[controller]")]
    public class InvoicesController : Controller
    {
        private readonly IInvoicesManager _invoicesManager;

        public InvoicesController(IInvoicesManager invoicesManager)
        {
            _invoicesManager = invoicesManager;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // return Ok(new string[] { "Invoice1", "Invoice2" });
            return Ok(await _invoicesManager.GetInvoicesAsync());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _invoicesManager.GetInvoiceAsync(id));
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]InvoiceAddViewModel invoiceAddViewModel)
        {
            if (ModelState.IsValid)
            {
                await _invoicesManager.SaveInvoiceAsync(new Invoice(invoiceAddViewModel.InvoiceNumber, invoiceAddViewModel.InvoiceEntryDate));
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody]InvoiceUpdateViewModel invoiceUpdateViewModel)
        {
            await _invoicesManager.UpdateInvoiceAsync(new Invoice(invoiceUpdateViewModel.InvoiceNumber, invoiceUpdateViewModel.InvoiceEntryDate));
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _invoicesManager.DeleteInvoiceAsync(id);
            return Ok();
        }
    }
}
