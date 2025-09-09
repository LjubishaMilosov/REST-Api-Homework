namespace Lotto3000App.DTOs
{
    public class CreateTicketRequest
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<int> Numbers { get; set; }
    }
}
