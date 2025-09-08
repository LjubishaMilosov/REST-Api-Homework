namespace Lotto3000App.DTOs
{
    public class SessionDto
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public List<int>? TicketIds { get; set; }
        public int? DrawId { get; set; }
    }
}
