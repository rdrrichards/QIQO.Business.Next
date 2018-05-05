using QIQO.Accounts.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QIQO.Business.Api.Accounts
{
    public class AccountAddViewModel
    {
        [Required]
        public int CompanyKey { get; set; }
        [Required]
        public QIQOAccountType AccountType { get; set; } = QIQOAccountType.Business;
        [Required]
        public string AccountCode { get; set; }
        [Required]
        public string AccountName { get; set; }
        [Required]
        public string AccountDesc { get; set; }
        public string AccountDba { get; set; }
        [Required]
        public DateTime AccountStartDate { get; set; }
        public DateTime? AccountEndDate { get; set; }
        public List<AccountAddressAddViewModel> AccountAddresses { get; set; }
    }
    public class AccountUpdateViewModel
    {
        public QIQOAccountType AccountType { get; set; }
        public string AccountName { get; set; }
        public string AccountDesc { get; set; }
        public string AccountDba { get; set; }
        public DateTime AccountStartDate { get; set; }
        public DateTime? AccountEndDate { get; set; }
        public List<AccountAddressUpdateViewModel> AccountAddresses { get; set; }
    }
    public class AccountAddressAddViewModel
    {
        [Required]
        public QIQOAddressType AddressType { get; set; } = QIQOAddressType.Billing;
        [Required]
        public int EntityKey { get; set; }
        [Required]
        public QIQOEntityType EntityType => QIQOEntityType.Account;
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
        [Required]
        public string AddedUserID { get; set; }
        public DateTime AddedDateTime { get; set; }
    }
    public class AccountAddressUpdateViewModel
    {
        [Required]
        public int AddressKey { get; set; }
        [Required]
        public QIQOAddressType AddressType { get; set; }
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
        [Required]
        public string UpdateUserID { get; set; }
        public DateTime UpdateDateTime { get; set; }
    }
}
