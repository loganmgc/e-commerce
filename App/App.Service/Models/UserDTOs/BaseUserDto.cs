namespace App.Service.Models.UserDTOs
{
    public abstract class BaseUserDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
