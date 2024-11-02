namespace App.Eticaret.Models.ViewModels.Category
{
    public class CategorySliderViewModel : BaseCategoryViewModel
    {
        public string Color { get; set; } = null!;
        public string IconCssClass { get; set; } = null!;
        public string? ImageUrl { get; set; }
    }
}
