using Lotto3000App.DataAccess.Implementation;
using Lotto3000App.Domain.Models;
using Lotto3000App.DTOs;
using Lotto3000App.Services.Interfaces;

namespace Lotto3000App.Services.Implementation
{
    public class SessionService : ISessionService<Session>
    {
        private readonly SessionRepository _sessionRepository;
        public SessionService(SessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public void Add(SessionDto sessionDto)
        {
            var session = new Session
            {
                StartTime = sessionDto.StartTime,
                EndTime = sessionDto.EndTime
                // Tickets and Draw should be set via other logic if needed
            };
            _sessionRepository.Add(session);
            sessionDto.Id = session.Id;
        }

        public void Delete(int id)
        {
            var session = _sessionRepository.GetById(id);
            if (session != null)
                _sessionRepository.Delete(session);
        }

        public List<SessionDto> GetAll()
        {
            return _sessionRepository.GetAll()
               .Select(s => new SessionDto
               {
                   Id = s.Id,
                   StartTime = s.StartTime,
                   EndTime = s.EndTime,
                   TicketIds = s.Tickets?.Select(t => t.Id).ToList(),
                   DrawId = s.Draw?.Id
               })
               .ToList();
        }

        public SessionDto GetById(int id)
        {
            var session = _sessionRepository.GetById(id);
            if (session == null) return null;
            return new SessionDto
            {
                Id = session.Id,
                StartTime = session.StartTime,
                EndTime = session.EndTime,
                TicketIds = session.Tickets?.Select(t => t.Id).ToList(),
                DrawId = session.Draw?.Id
            };
        }

        public void Update(SessionDto sessionDto)
        {
            var session = _sessionRepository.GetById(sessionDto.Id);
            if (session == null) return;
            session.StartTime = sessionDto.StartTime;
            session.EndTime = sessionDto.EndTime;
            _sessionRepository.Update(session);
        }
    }
}
