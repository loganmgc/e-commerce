namespace App.Service.Models.CategoryDTOs
{
    public class CategoryDto : BaseCategoryDto
    {
        public int CategoryId { get; set; }
        public string? ImageUrl { get; set; }
    }
}
