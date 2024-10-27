namespace App.Service.Models.UserDTOs
{
    public class GetUserDto
    {
        public int UserId { get; set; }
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string RoleName { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
