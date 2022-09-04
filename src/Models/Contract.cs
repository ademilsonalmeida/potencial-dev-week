namespace dev_week.src.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string TokenId { get; set; }
        public DateTime CreatedAt { get; set; }
        public Decimal Value { get; set; }
        public bool Paid { get; set; }                
    }
}