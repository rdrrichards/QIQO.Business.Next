﻿using QIQO.Companies.Domain;
using System.ComponentModel.DataAnnotations;

namespace QIQO.Business.Api.Companies
{
    public class CompanyAddressBaseViewModel
    {
        [Required]
        public QIQOCompanyAddressType AddressType { get; set; } = QIQOCompanyAddressType.Billing;
        [Required]
        public int EntityKey { get; set; }
        [Required]
        public QIQOCompanyEntityType EntityType => QIQOCompanyEntityType.Company;
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
