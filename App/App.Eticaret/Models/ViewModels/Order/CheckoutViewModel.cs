using System.ComponentModel.DataAnnotations;

namespace App.Eticaret.Models.ViewModels.Order
{
    public class CheckoutViewModel
    {
        [Required(ErrorMessage ="Address is required"),
            MinLength(10, ErrorMessage = "Minimum 10 characters"),
            MaxLength(250, ErrorMessage = "Maximum 250 characters"),
            DataType(DataType.MultilineText)]
        public string Address { get; set; } = null!;
        public int UserId { get; set; } = 0;
    }
}
