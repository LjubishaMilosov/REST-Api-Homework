using Lotto3000App.DataAccess.Interfaces;
using Lotto3000App.Domain.Models;

namespace Lotto3000App.DataAccess.Implementation
{
    public class TicketRepository : ITicketRepository<Ticket>
    {
        private readonly Lotto3000DbContext _context;
        public TicketRepository(Lotto3000DbContext context)
        {
            _context = context;
        }
        public void Add(Ticket entity)
        {
            _context.Tickets.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Ticket entity)
        {
            _context.Tickets.Remove(entity);
            _context.SaveChanges();
        }

        public List<Ticket> GetAll()
        {
            return _context.Tickets.ToList();
        }

        public Ticket GetById(int id)
        {
            var ticket = _context.Tickets.FirstOrDefault(t => t.Id == id);
            if (ticket == null)
            {
                throw new Exception($"ticket with {id} not found.");
            }
            return ticket;
        }

        public void Update(Ticket entity)
        {
            _context.Tickets.Update(entity);
            _context.SaveChanges();
        }
    }
}
