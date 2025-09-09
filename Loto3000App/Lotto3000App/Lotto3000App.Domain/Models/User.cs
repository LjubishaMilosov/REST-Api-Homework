using System.Net.Sockets;
using Lotto3000App.Domain.Enums;

namespace Lotto3000App.Domain.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; } 
        public RoleEnum Role { get; set; } 
        public List<Ticket> Tickets { get; set; }
        public List<Winner> Wins { get; set; }
    }
}

