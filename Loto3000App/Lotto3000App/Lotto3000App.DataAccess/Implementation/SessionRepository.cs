using Lotto3000App.DataAccess.Interfaces;
using Lotto3000App.Domain.Models;

namespace Lotto3000App.DataAccess.Implementation
{
    public class SessionRepository : ISessionRepository<Session>
    {
        private readonly Lotto3000DbContext _context;
        public SessionRepository(Lotto3000DbContext context)
        {
            _context = context;
        }
        public void Add(Session entity)
        {
            _context.Sessions.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Session entity)
        {
            _context.Sessions.Remove(entity);
            _context.SaveChanges();
        }

        public List<Session> GetAll()
        {
            return _context.Sessions.ToList();
        }

        public Session GetById(int id)
        {
            var session = _context.Sessions.FirstOrDefault(d => d.Id == id);
            if (session == null)
            {
                throw new Exception($"session with {id} not found.");
            }
            return session;
        }

        public void Update(Session entity)
        {
            _context.Sessions.Update(entity);
            _context.SaveChanges();
        }
    }
}
