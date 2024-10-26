namespace App.Data.Data.Entities
{
    public class DiscountEntity
    {
        public int DiscountId { get; set; }
        public byte DiscountRate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Enabled { get; set; } = true;
        public DateTime CreatedAt { get; set; }
    }
}
