namespace Lotto3000App.DTOs
{
    public class DrawDto
    {
        public int Id { get; set; }
        public DateTime DrawTime { get; set; }
        public List<int> DrawnNumbers { get; set; } = new();
        public int SessionId { get; set; }
    }
}
