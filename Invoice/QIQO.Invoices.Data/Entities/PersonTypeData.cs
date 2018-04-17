using QIQO.Business.Core.Contracts;
using System;

namespace QIQO.Invoices.Data
{
    public class PersonTypeData : CommonData, IEntity
    {
        public int PersonTypeKey { get; set; }
        public string PersonTypeCategory { get; set; }
        public string PersonTypeCode { get; set; }
        public string PersonTypeName { get; set; }
        public string PersonTypeDesc { get; set; }
    }
}