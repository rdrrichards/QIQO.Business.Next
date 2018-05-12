using QIQO.Invoices.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace QIQO.Business.Api.Invoices
{
    public class InvoiceAddressAddViewModel : InvoiceAddressBaseViewModel
    {
        [Required]
        public string AddedUserID { get; set; }
        public DateTime AddedDateTime { get; set; }
    }
}
