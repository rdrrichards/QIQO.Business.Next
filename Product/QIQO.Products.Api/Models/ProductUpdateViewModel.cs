using System.ComponentModel.DataAnnotations;

namespace QIQO.Business.Api.Products
{
    public class ProductUpdateViewModel
    {
        [Required]
        public int ProductKey { get; set; }
        [Required]
        public int ProductType { get; set; }
        [Required]
        public string ProductName { get; set; } = string.Empty;
        [Required]
        public string ProductDesc { get; set; } = string.Empty;
        public string ProductNameShort { get; set; } = string.Empty;
        public string ProductNameLong { get; set; } = string.Empty;
        public string ProductImagePath { get; set; } = string.Empty;
    }
}
