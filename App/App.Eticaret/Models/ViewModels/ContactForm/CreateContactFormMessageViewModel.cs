using System.ComponentModel.DataAnnotations;

namespace App.Eticaret.Models.ViewModels.ContactForm
{
    public class CreateContactFormMessageViewModel
    {
        [Required(ErrorMessage = "Name is required"),
            MinLength(2, ErrorMessage = "Must enter a minimum of 2 characters"),
            MaxLength(100, ErrorMessage = "Maximum 100 characters")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Email is required"),
            EmailAddress(ErrorMessage = "Must be email address"),
            MaxLength(256, ErrorMessage = "Maximum 256 characters")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Message is required"),
            MinLength(10, ErrorMessage = "Must enter a minimum of 10 characters"),
            MaxLength(1000, ErrorMessage = "Maximum 256 characters")]
        public string Message { get; set; } = null!;
    }
}
