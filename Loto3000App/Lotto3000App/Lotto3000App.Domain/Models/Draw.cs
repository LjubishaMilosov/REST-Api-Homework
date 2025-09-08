namespace Lotto3000App.Domain.Models
{
    public class Draw : BaseEntity
    {
        public DateTime DrawTime { get; set; }
        public List<int> DrawnNumbers { get; set; } 
        public int SessionId { get; set; }
        public Session Session { get; set; }
    }
}
