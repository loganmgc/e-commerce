namespace App.Service.Models.UserDTOs
{
    public class GetUserWithoutIdDto : BaseUserDto
    {
        public string Email { get; set; } = null!;
        public string RoleName { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
