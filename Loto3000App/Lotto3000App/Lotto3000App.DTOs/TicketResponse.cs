namespace Lotto3000App.DTOs
{
    public class TicketResponse
    {
        public int TicketId { get; set; }
        public int SessionId { get; set; }
        public string Username { get; set; }
        public List<int> Numbers { get; set; }
        public DateTime SubmittedAt { get; set; }
    }
}
