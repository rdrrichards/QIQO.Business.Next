namespace QIQO.Products.Data
{
    public class ProductData : CommonData
    {
        public int ProductKey { get; set; }
        public int ProductTypeKey { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public string ProductNameShort { get; set; }
        public string ProductNameLong { get; set; }
        public string ProductImagePath { get; set; }
    }
}