using System.ComponentModel.DataAnnotations;

namespace App.Eticaret.Models.ViewModels.Product
{
    public class UpdateProductViewModel
    {
        [Required]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Name is required"),
            MinLength(2, ErrorMessage = "Minimum 2 characters"),
            MaxLength(100, ErrorMessage = "Maximum 100 characters")]
        public string Name { get; set; } = null!;

        [MaxLength(1000, ErrorMessage = "Maximum 1000 characters")]
        public string? Details { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Stock is required")]
        [Range(1, byte.MaxValue, ErrorMessage = "Stock amount must be at least 1")]
        public byte StockAmount { get; set; }

        [Required(ErrorMessage = "Please select a category")]
        public int CategoryId { get; set; }
        public int? DiscountId { get; set; }
    }
}
