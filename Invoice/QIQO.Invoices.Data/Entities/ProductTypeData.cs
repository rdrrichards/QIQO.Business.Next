using QIQO.Business.Core.Contracts;
using System;

namespace QIQO.Invoices.Data
{
    public class ProductTypeData : CommonData, IEntity
    {
        public int ProductTypeKey { get; set; }
        public string ProductTypeCategory { get; set; }
        public string ProductTypeCode { get; set; }
        public string ProductTypeName { get; set; }
        public string ProductTypeDesc { get; set; }
    }
}