using System.ComponentModel.DataAnnotations;

namespace App.Service.Models.ProductDTOs
{
    public class AddProductDto : BaseProductDto
    {
        public int SellerId { get; set; }
        public string? Details { get; set; }
        public byte StockAmount { get; set; }
        public int? DiscountId { get; set; }
    }
}
