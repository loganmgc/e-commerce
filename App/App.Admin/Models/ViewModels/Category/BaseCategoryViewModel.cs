using System.ComponentModel.DataAnnotations;

namespace App.Admin.Models.ViewModels.Category
{
    public abstract class BaseCategoryViewModel
    {
        [Required, StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = null!;
        [Required, StringLength(7, MinimumLength = 3)]
        public string Color { get; set; } = null!;
        [Required, StringLength(50, MinimumLength = 2)]
        public string IconCssClass { get; set; } = null!;
    }
}
