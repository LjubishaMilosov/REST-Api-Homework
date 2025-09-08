using Lotto3000App.Domain.Models;
using Lotto3000App.DTOs;

namespace Lotto3000App.Services.Interfaces
{
    public interface ISessionService<Session> where Session : BaseEntity
    {
        List<SessionDto> GetAll();
        SessionDto GetById(int id);
        void Add(SessionDto entity);
        void Update(SessionDto entity);
        void Delete(int id);
    }
}
