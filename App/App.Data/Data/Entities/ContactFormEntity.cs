namespace App.Data.Data.Entities
{
   public class ContactFormEntity
    {
        public int ContacFormId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Message { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? SeenAt { get; set; } = null;
    }
}
