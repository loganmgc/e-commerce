namespace App.Service.Models.CategoryDTOs
{
    public abstract class BaseCategoryDto
    {
        public string Name { get; set; } = null!;
        public string Color { get; set; } = null!;
        public string IconCssClass { get; set; } = null!;
    }
}
