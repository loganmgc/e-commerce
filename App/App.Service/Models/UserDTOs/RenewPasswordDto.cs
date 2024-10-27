
namespace App.Service.Models.UserDTOs
{
    public class RenewPasswordDto
    {
        public int UserId { get; set; }
        public string OldPassword { get; set; } = null!;
        public string NewPassword { get; set; } = null!;
    }
}
