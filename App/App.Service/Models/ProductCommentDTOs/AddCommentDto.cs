using System.ComponentModel.DataAnnotations;

namespace App.Service.Models.ProductCommentDTOs
{
    public class AddCommentDto
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required, StringLength(500, MinimumLength =2)]
        public string Text { get; set; } = null!;
        [Required, Range(1,5)]
        public byte StarCount { get; set; }
    }
}
