using QIQO.Business.Core.Contracts;
using QIQO.Invoices.Data;
using System;

namespace QIQO.Invoices.Domain
{
    public class ProductType : IModel
    {
        public ProductType(ProductTypeData productTypeData)
        {
            ProductTypeKey = productTypeData.ProductTypeKey;
            ProductTypeCategory = productTypeData.ProductTypeCategory;
            ProductTypeCode = productTypeData.ProductTypeCode;
            ProductTypeName = productTypeData.ProductTypeName;
            ProductTypeDesc = productTypeData.ProductTypeDesc;
            AddedUserID = productTypeData.AuditAddUserId;
            AddedDateTime = productTypeData.AuditAddDatetime;
            UpdateUserID = productTypeData.AuditUpdateUserId;
            UpdateDateTime = productTypeData.AuditUpdateDatetime;
        }
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
