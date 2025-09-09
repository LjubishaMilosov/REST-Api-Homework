namespace Lotto3000App.DTOs
{
    public class WinnerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserId { get; set; }
        public List<int> WinningNumbers { get; set; } = new();
        public int DrawId { get; set; }
        public int TicketId { get; set; }
        public int PrizeId { get; set; }
        public int Matches { get; set; }
        public DateTime CreatedAt { get; set; }
        public string PrizeName { get; set; }
    }
}
