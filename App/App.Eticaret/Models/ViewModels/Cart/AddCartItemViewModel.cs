using System.ComponentModel.DataAnnotations;

namespace App.Eticaret.Models.ViewModels.Cart
{
    public class AddCartItemViewModel : BaseCartItemViewModel
    {
        [Required]
        public int UserId { get; set; }
    }
}
