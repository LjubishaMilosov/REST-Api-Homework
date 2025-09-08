namespace Lotto3000App.Domain.Models
{
    public class Session : BaseEntity
    {
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public List<Ticket> Tickets { get; set; }
        public Draw Draw { get; set; }
    }
}
