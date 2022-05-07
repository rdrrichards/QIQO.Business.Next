using QIQO.Accounts.Domain;
using System.ComponentModel.DataAnnotations;

namespace QIQO.Business.Api.Accounts
{
    public class AccountAddressBaseViewModel
    {
        [Required]
        public QIQOAccountAddressType AddressType { get; set; } = QIQOAccountAddressType.Billing;
        [Required]
        public int EntityKey { get; set; }
        [Required]
        public QIQOAccountEntityType EntityType => QIQOAccountEntityType.Account;
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
