
using Lotto3000App.Domain.Models;

namespace Lotto3000App.DataAccess.Interfaces
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        List<Ticket> GetByUserId(int userId);
    }
}
