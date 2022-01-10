using System;
using System.ComponentModel.DataAnnotations;

namespace QIQO.Business.Api.Invoices
{
    public class InvoiceAddressUpdateViewModel : InvoiceAddressBaseViewModel
    {
        [Required]
        public string UpdateUserID { get; set; }
        public DateTime UpdateDateTime { get; set; }
    }
}
