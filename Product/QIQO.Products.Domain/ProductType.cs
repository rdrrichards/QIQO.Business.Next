using QIQO.Business.Core.Contracts;
using System;

namespace QIQO.Products.Domain
{
    public class ProductType : IModel
    {        
        public int ProductTypeKey { get; private set; }        
        public string ProductTypeCategory { get; private set; }        
        public string ProductTypeCode { get; private set; }        
        public string ProductTypeName { get; private set; }        
        public string ProductTypeDesc { get; private set; }        
        public string AddedUserID { get; private set; }        
        public DateTime AddedDateTime { get; private set; }        
        public string UpdateUserID { get; private set; }        
        public DateTime UpdateDateTime { get; private set; }
    }
}
