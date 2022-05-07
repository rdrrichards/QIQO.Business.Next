using System.ComponentModel.DataAnnotations;

namespace QIQO.Business.Api.Products
{
    public class ProductAddViewModel
    {
        [Required]
        public int ProductType { get; set; }
        [Required]
        public string ProductCode { get; set; } = string.Empty;
        [Required]
        public string ProductName { get; set; } = string.Empty;
        [Required]
        public string ProductDesc { get; set; } = string.Empty;
        public string ProductNameShort { get; set; } = string.Empty;
        public string ProductNameLong { get; set; } = string.Empty;
        public string ProductImagePath { get; set; } = string.Empty;
    }
}
