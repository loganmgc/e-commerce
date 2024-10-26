namespace App.Data.Data.Entities
{
    public class BlogCommentEntity
    {
        public int BlogCommentId { get; set; }
        public int BlogId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Comment { get; set; } = null!;
        public bool IsApproved { get; set; }
        public DateTime CreatedAt { get; set; }

        public BlogEntity Blog { get; set; } = null!;
    }
}
