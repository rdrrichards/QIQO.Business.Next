using System.ComponentModel.DataAnnotations;

namespace QIQO.Business.Api.Invoices
{
    public class InvoiceAddressAddViewModel : InvoiceAddressBaseViewModel
    {
        [Required]
        public string AddedUserID { get; set; } = string.Empty;
        public DateTime AddedDateTime { get; set; }
    }
}
