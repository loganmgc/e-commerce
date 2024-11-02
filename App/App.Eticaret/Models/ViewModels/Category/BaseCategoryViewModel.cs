namespace App.Eticaret.Models.ViewModels.Category
{
    public abstract class BaseCategoryViewModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
    }
}
