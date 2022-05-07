using System.ComponentModel.DataAnnotations;

namespace QIQO.Business.Api.Invoices
{
    public class InvoiceAddressUpdateViewModel : InvoiceAddressBaseViewModel
    {
        [Required]
        public string UpdateUserID { get; set; } = string.Empty;
        public DateTime UpdateDateTime { get; set; }
    }
}
