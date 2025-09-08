
using Lotto3000App.Domain.Models;

namespace Lotto3000App.DataAccess.Interfaces
{
    public interface ITicketRepository<Ticket> where Ticket : BaseEntity
    {
        List<Ticket> GetAll();
        Ticket GetById(int id);
        void Add(Ticket entity);
        void Update(Ticket entity);
        void Delete(Ticket entity);
    }
}
