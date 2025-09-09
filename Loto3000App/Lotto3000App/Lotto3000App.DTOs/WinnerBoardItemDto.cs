namespace Lotto3000App.DTOs
{
    public record WinnerBoardItemDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        List<int> WinningNumbers { get; set; }
        public string Prize { get; set; }
        public int Matches { get; set; }
        DateTime CreatedAt { get; set; }
    }
}
