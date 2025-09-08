using System.Net.Sockets;
using Lotto3000App.Domain.Enums;

namespace Lotto3000App.Domain.Models
{
    public class User : BaseEntity
    {
        public string Username { get; set; } 
        public RoleEnum Role { get; set; } 
        public List<Ticket> Tickets { get; set; }
    }
}

