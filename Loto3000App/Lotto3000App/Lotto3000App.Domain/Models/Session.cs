namespace Lotto3000App.Domain.Models
{
    public class Session : BaseEntity
    {
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool IsActive { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<Draw> Draws { get; set; }
    }
}
