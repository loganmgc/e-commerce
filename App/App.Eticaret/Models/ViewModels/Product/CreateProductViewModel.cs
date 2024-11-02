using System.ComponentModel.DataAnnotations;

namespace App.Eticaret.Models.ViewModels.Product
{
    public class CreateProductViewModel :BaseProductViewModel
    {

        [MaxLength(1000, ErrorMessage ="Maximum 1000 characters")]
        public string? Details { get; set; }

        [Required(ErrorMessage = "Stock is required")]
        [Range(1, byte.MaxValue, ErrorMessage = "Stock amount must be at least 1")]
        public byte StockAmount { get; set; }

        [Required(ErrorMessage = "Please select a category")]
        public int CategoryId { get; set; }
        public int? DiscountId { get; set; }
    }
}
