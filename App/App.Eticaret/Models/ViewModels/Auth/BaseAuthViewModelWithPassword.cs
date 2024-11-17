using System.ComponentModel.DataAnnotations;

namespace App.Eticaret.Models.ViewModels.Auth
{
    public class BaseAuthViewModelWithPassword : BaseAuthViewModel
    {
        [Required(ErrorMessage = "Password is required"),
            DataType(DataType.Password),
            MinLength(1)]
        public string Password { get; set; } = null!;
    }
}
