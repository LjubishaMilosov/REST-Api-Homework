namespace Lotto3000App.DTOs
{
    public class WinnerDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Prize { get; set; }
        public List<int> WinningNumbers { get; set; } = new();
        public int DrawId { get; set; }
    }
}
