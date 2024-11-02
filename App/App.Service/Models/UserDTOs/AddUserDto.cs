namespace App.Service.Models.UserDTOs
{
    public class AddUserDto : BaseUserDto
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
