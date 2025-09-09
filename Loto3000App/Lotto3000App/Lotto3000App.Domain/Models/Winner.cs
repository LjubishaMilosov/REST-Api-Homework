namespace Lotto3000App.Domain.Models
{
    public class Winner : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<int> WinningNumbers { get; set; }
        public int DrawId { get; set; }
        public int TicketId { get; set; }
        public int PrizeId { get; set; }
        public Draw Draw { get; set; }
        public int Matches { get; set; }
        public DateTime CreatedAt { get; set; }
        public Ticket Ticket { get; set; }
        public Prize Prize { get; set; } = default!;

    }
}
