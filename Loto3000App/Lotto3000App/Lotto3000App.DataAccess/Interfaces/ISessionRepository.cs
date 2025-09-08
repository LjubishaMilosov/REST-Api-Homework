using Lotto3000App.Domain.Models;

namespace Lotto3000App.DataAccess.Interfaces
{
    public interface ISessionRepository<Session> where Session : BaseEntity
    {
        List<Session> GetAll();
        Session GetById(int id);
        void Add(Session entity);
        void Update(Session entity);
        void Delete(Session entity);
    }
}
