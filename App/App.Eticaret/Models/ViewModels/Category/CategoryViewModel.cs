namespace App.Eticaret.Models.ViewModels.Category
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string Color { get; set; } = null!;
        public string IconCssClass { get; set; } = null!;
    }
}
