using QIQO.Business.Core.Contracts;
using System;

namespace QIQO.Invoices.Data
{
    public class AddressTypeData : CommonData, IEntity
    {
        public int AddressTypeKey { get; set; }
        public string AddressTypeCode { get; set; }
        public string AddressTypeName { get; set; }
        public string AddressTypeDesc { get; set; }
    } 
}