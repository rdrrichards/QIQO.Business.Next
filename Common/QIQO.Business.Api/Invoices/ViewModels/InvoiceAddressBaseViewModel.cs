﻿using QIQO.Invoices.Domain;
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
