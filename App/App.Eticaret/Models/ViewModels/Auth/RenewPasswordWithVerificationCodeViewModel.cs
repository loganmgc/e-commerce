using System.ComponentModel.DataAnnotations;

namespace App.Eticaret.Models.ViewModels.Auth
{
    public class RenewPasswordWithVerificationCodeViewModel
    {
        [Required]
        public string VerificationCode { get; set; } = null!;
        [Required, DataType(DataType.Password)]

        public string NewPassword { get; set; } = null!;
        [Required,
            DataType(DataType.Password),
            Compare("NewPassword", ErrorMessage = "The password and confirmation password do not match")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
