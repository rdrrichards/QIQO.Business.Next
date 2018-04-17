using QIQO.Business.Core.Contracts;
using System;

namespace QIQO.Invoices.Domain
{
    public class ProductType : IModel
    {        
        public int ProductTypeKey { get; set; }        
        public string ProductTypeCategory { get; set; }        
        public string ProductTypeCode { get; set; }        
        public string ProductTypeName { get; set; }        
        public string ProductTypeDesc { get; set; }        
        public string AddedUserID { get; set; }        
        public DateTime AddedDateTime { get; set; }        
        public string UpdateUserID { get; set; }        
        public DateTime UpdateDateTime { get; set; }
    }
}
