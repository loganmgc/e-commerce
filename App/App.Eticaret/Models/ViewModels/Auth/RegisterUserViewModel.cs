using System.ComponentModel.DataAnnotations;

namespace App.Eticaret.Models.ViewModels.Auth
{
    public class RegisterUserViewModel
    {
        [Required(ErrorMessage = "Email is required"),
            EmailAddress]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Firstname is required"),
            MinLength(2, ErrorMessage = "Minimum 2 characters"),
            MaxLength(50, ErrorMessage = "Maximum 50 characters")]
        public string FirstName { get; set; } = null!;
        [Required(ErrorMessage = "Lastname is required"),
            MinLength(2, ErrorMessage = "Minimum 2 characters"),
            MaxLength(50, ErrorMessage = "Maximum 50 characters")]
        public string LastName { get; set; } = null!;
        [Required(ErrorMessage = "Password is required"),
            DataType(DataType.Password),
            MinLength(1)]
        public string Password { get; set; } = null!;
        [Required(ErrorMessage = "Password is required"),
            DataType(DataType.Password),
            Compare("Password", ErrorMessage = "The password and confirmation password do not match")]
        public string PasswordRepeat { get; set; } = null!;
    }
}
