using System.ComponentModel.DataAnnotations;

namespace App.Eticaret.Models.ViewModels.Product
{
    public class CreateProductViewModel
    {
        [Required(ErrorMessage = "Name is required"),
            StringLength(100, MinimumLength =2, ErrorMessage = "Minimum 2 maximum 100 characters")]
        public string Name { get; set; } = null!;

        [MaxLength(1000, ErrorMessage ="Maximum 1000 characters")]
        public string? Details { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Stock is required")]
        [Range(1, byte.MaxValue, ErrorMessage = "Stock amount must be at least 1")]
        public byte StockAmount { get; set; }

        [Required(ErrorMessage = "Please select a category")]
        public int CategoryId { get; set; }
        [Required]
        public int SellerId { get; set; }
    }
}
