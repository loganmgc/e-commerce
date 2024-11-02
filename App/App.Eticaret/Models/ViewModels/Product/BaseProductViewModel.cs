using System.ComponentModel.DataAnnotations;

namespace App.Eticaret.Models.ViewModels.Product
{
    public abstract class BaseProductViewModel
    {
        [Required(ErrorMessage = "Name is required"),
            MinLength(2, ErrorMessage = "Minimum 2 characters"),
            MaxLength(100, ErrorMessage = "Maximum 100 characters")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value")]
        public decimal Price { get; set; }
    }
}
