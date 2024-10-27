using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace App.Eticaret.Models.ViewModels.Profile
{
    public class ProfileDetailsViewModel
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
