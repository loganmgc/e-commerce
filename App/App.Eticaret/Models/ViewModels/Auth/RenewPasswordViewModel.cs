using System.ComponentModel.DataAnnotations;

namespace App.Eticaret.Models.ViewModels.Auth
{

    public class RenewPasswordViewModel
    {
        [Required, DataType(DataType.Password)]
        public string OldPassword { get; set; } = null!;

        [Required, DataType(DataType.Password)]
        public string NewPassword { get; set; } = null!;
        [Required,
            DataType(DataType.Password),
            Compare("Password", ErrorMessage = "The password and confirmation password do not match")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
