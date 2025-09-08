namespace Lotto3000App.Domain.Models
{
    public class Winner : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public List<int> WinningNumbers { get; set; }
        public string Prize { get; set; }
        public int DrawId { get; set; }
        public Draw Draw { get; set; }
    }
}
