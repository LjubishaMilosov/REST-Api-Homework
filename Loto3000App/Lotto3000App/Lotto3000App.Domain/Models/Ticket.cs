namespace Lotto3000App.Domain.Models
{
    public class Ticket : BaseEntity
    {
        public int UserId { get; set; }
        public int SessionId { get; set; }
        public User User { get; set; }
        public List<int> Numbers { get; set; } 
        public DateTime SubmittedAt { get; set; }
        public Session Session { get; set; }
        public List<Winner> Winners { get; set; }
    }
}
