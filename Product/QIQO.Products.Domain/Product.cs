using QIQO.Business.Core.Contracts;
using QIQO.Products.Data;
using System;

namespace QIQO.Products.Domain
{
    public class Product: IModel
    {
        public Product(ProductData productData)
        {
            ProductKey = productData.ProductKey;
            ProductType = (QIQOProductType)productData.ProductTypeKey;
            ProductName = productData.ProductName;
            ProductDesc = productData.ProductDesc;
            ProductCode = productData.ProductCode;
            ProductNameShort = productData.ProductNameShort;
            ProductNameLong = productData.ProductNameLong;
            ProductImagePath = productData.ProductImagePath;
            AddedUserID = productData.AuditAddUserId;
            AddedDateTime = productData.AuditAddDatetime;
            UpdateUserID = productData.AuditUpdateUserId;
            UpdateDateTime = productData.AuditUpdateDatetime;
            ProductDescCombo = productData.ProductCode.PadRight(21 - productData.ProductCode.Length) + productData.ProductDesc;
        }
        public Product(string productCode, string productName, string productDesc, string productNameShort, string productNameLong, string productImagePath)
        {
            ProductCode = productCode;
            ProductName = productName;
            ProductDesc = productDesc;
            ProductNameShort = productNameShort;
            ProductNameLong = productNameLong;
            ProductImagePath = productImagePath;
        }
        public int ProductKey { get; private set; }        
        public QIQOProductType ProductType { get; private set; } = QIQOProductType.Sweet9;        
        // public ProductType ProductTypeData { get; private set; } = new ProductType();        
        public string ProductCode { get; private set; }        
        public string ProductName { get; private set; }        
        public string ProductDesc { get; private set; }        
        public string ProductNameShort { get; private set; }        
        public string ProductNameLong { get; private set; }        
        public string ProductImagePath { get; private set; }        
        //public List<EntityAttribute> ProductAttributes { get; private set; } = new List<EntityAttribute>();        
        public string ProductDescCombo { get; private set; }        
        public string AddedUserID { get; private set; }        
        public DateTime AddedDateTime { get; private set; }        
        public string UpdateUserID { get; private set; }        
        public DateTime UpdateDateTime { get; private set; }
    }
}
