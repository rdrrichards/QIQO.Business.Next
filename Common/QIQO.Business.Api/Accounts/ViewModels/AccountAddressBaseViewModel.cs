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
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
        [Required]
        public string AddressCity { get; set; }
        [Required]
        public string AddressState { get; set; }
        public string AddressCounty { get; set; }
        public string AddressCountry { get; set; }
        [Required]
        public string AddressPostalCode { get; set; }
        public string AddressNotes { get; set; }
        public bool AddressDefaultFlag { get; set; }
        public bool AddressActiveFlag { get; set; }
    }
}
