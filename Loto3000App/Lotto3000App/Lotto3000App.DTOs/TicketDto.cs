namespace Lotto3000App.DTOs
{
    public class TicketDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<int> Numbers { get; set; } = new();
        public DateTime SubmittedAt { get; set; }
        public int SessionId { get; set; }
    }
}
