using System.ComponentModel.DataAnnotations;

namespace App.Eticaret.Models.ViewModels.Cart
{
    public abstract class BaseCartItemViewModel
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public byte Quantity { get; set; }
    }
}
