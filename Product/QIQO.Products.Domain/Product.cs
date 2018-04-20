using QIQO.Business.Core.Contracts;
using System;
using System.Collections.Generic;

namespace QIQO.Products.Domain
{
    public class Product: IModel
    {
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
        public ProductType ProductTypeData { get; private set; } = new ProductType();        
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
