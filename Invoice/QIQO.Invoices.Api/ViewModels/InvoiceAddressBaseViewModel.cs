using QIQO.Invoices.Domain;
using System.ComponentModel.DataAnnotations;

namespace QIQO.Business.Api.Invoices
{
    public class InvoiceAddressBaseViewModel
    {
        [Required]
        public int AddressKey { get; set; }
        [Required]
        public QIQOInvoiceAddressType AddressType { get; set; }
        [Required]
        public string AddressLine1 { get; set; } = string.Empty;
        public string AddressLine2 { get; set; } = string.Empty;
        public string AddressLine3 { get; set; } = string.Empty;
        public string AddressLine4 { get; set; } = string.Empty;
        [Required]
        public string AddressCity { get; set; } = string.Empty;
        [Required]
        public string AddressState { get; set; } = string.Empty;
        public string AddressCounty { get; set; } = string.Empty;
        public string AddressCountry { get; set; } = string.Empty;
        [Required]
        public string AddressPostalCode { get; set; } = string.Empty;
        public string AddressNotes { get; set; } = string.Empty;
        public bool AddressDefaultFlag { get; set; }
        public bool AddressActiveFlag { get; set; }
    }
}
