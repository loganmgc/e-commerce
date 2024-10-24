using System.ComponentModel.DataAnnotations;

namespace App.Service.Models.ProductDTOs
{
    public class AddProductDto
    {
        [Required]
        public int SellerId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required, StringLength(100, MinimumLength =2)]
        public string Name { get; set; } = null!;
        [Required, DataType(DataType.Currency), Range(0,double.MaxValue)]
        public decimal Price { get; set; }
        [MaxLength(1000)]
        public string? Details { get; set; }
        [Required, Range(0, byte.MaxValue)]
        public byte StockAmount { get; set; }
    }
}
