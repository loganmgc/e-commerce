namespace App.Service.Models.UserDTOs
{
    public class UpdateUserDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
