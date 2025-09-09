namespace Lotto3000App.Domain.Models
{
    public class Draw : BaseEntity
    {
        public DateTime DrawTime { get; set; }
        public List<int> DrawnNumbers { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }
        public User InitiatedBy { get; set; }
        public int InitiatedByUserId { get; set; } // Admin
        public List<Winner> Winners { get; set; }
    }
}
