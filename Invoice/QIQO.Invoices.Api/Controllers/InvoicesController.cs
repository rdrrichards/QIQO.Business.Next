﻿using Microsoft.AspNetCore.Mvc;
using QIQO.Invoices.Domain;
using QIQO.Invoices.Manager;

namespace QIQO.Business.Api.Invoices
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
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

        /// <summary>
        /// This finds a list of invoices by company
        /// </summary>
        /// <returns></returns>
        [HttpGet("search")]
        public async Task<IActionResult> Find(int companyKey, string term)
        {
            // return Ok(new string[] { "Account1", "Account2" });
            return Ok(await _invoicesManager.FindInvoicesAsync(companyKey, term));
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
            await _invoicesManager.SaveInvoiceAsync(new Invoice(invoiceUpdateViewModel.InvoiceKey, invoiceUpdateViewModel.InvoiceEntryDate));
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
