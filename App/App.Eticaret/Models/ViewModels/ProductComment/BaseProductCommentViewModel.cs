using System.ComponentModel.DataAnnotations;

namespace App.Eticaret.Models.ViewModels.ProductComment
{
    public abstract class BaseProductCommentViewModel
    {
        [Required]
        public int UserId { get; set; }
        [Required,
           StringLength(500, MinimumLength = 2, ErrorMessage = "Minimum 2 maximum 500 characters")]
        public string Text { get; set; } = null!;
        [Required,
            Range(1, 5, ErrorMessage = "Should be in the range of 1 to 5")]
        public byte StarCount { get; set; }
    }
}
