using System.ComponentModel.DataAnnotations;

namespace QIQO.Business.Api.Products
{
    public class ProductAddViewModel
    {
        [Required]
        public int ProductType { get; set; }
        [Required]
        public string ProductCode { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductDesc { get; set; }
        public string ProductNameShort { get; set; }
        public string ProductNameLong { get; set; }
        public string ProductImagePath { get; set; }
    }
    public class ProductUpdateViewModel
    {
        [Required]
        public int ProductKey { get; set; }
        [Required]
        public int ProductType { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductDesc { get; set; }
        public string ProductNameShort { get; set; }
        public string ProductNameLong { get; set; }
        public string ProductImagePath { get; set; }
    }
}
