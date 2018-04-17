using QIQO.Business.Core.Contracts;
using System;

namespace QIQO.Invoices.Data
{
    public class AddressPostalData : IEntity
    {
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string StateCode { get; set; }
        public string StateFullName { get; set; }
        public string CityName { get; set; }
        public string CountyName { get; set; }
        public int TimeZone { get; set; }
    }
}