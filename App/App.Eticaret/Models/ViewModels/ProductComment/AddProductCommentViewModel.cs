using System.ComponentModel.DataAnnotations;

namespace App.Eticaret.Models.ViewModels.ProductComment
{
    public class AddProductCommentViewModel :BaseProductCommentViewModel
    {
        [Required]
        public int ProductId { get; set; }
    }
}
