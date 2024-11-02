using System.ComponentModel.DataAnnotations;

namespace App.Admin.Models.ViewModels.Category
{
    public class EditCategoryViewModel : BaseCategoryViewModel
    {
        [Required]
        public int CategoryId { get; set; }
    }
}
