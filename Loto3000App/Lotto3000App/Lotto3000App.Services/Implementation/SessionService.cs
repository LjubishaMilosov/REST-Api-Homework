using Lotto3000App.DataAccess.Implementation;
using Lotto3000App.DataAccess.Interfaces;
using Lotto3000App.Domain.Models;
using Lotto3000App.DTOs;
using Lotto3000App.Services.Interfaces;

namespace Lotto3000App.Services.Implementation
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _sessionRepository;
        public SessionService(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
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
                   DrawId = s.Draws?.LastOrDefault()?.Id
               })
               .ToList();
        }

        public void Add(SessionDto sessionDto)
        {
            if (sessionDto == null)
                throw new ArgumentNullException(nameof(sessionDto), "Session cannot be null");
            if (sessionDto.StartTime == default)
                throw new ArgumentException("Session start time must be specified");

            var session = new Session
            {
                StartTime = sessionDto.StartTime,
                EndTime = sessionDto.EndTime,
                IsActive = true
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

        public SessionDto GetActiveSession()
        {
            var session = _sessionRepository.GetActiveSession();
            if (session == null)
            {
                throw new Exception("No active session found.");
            };
            return new SessionDto
            {
                Id = session.Id,
                StartTime = session.StartTime,
                EndTime = session.EndTime,
                TicketIds = session.Tickets?.Select(t => t.Id).ToList(),
                DrawId = session.Draws?.LastOrDefault()?.Id
            };
        }

        public SessionDto GetById(int id)
        {
            var session = _sessionRepository.GetById(id);
            if (session == null)
            {
                throw new Exception($"Session with id {id} not found.");
            } ;
            return new SessionDto
            {
                Id = session.Id,
                StartTime = session.StartTime,
                EndTime = session.EndTime,
                TicketIds = session.Tickets?.Select(t => t.Id).ToList(),
                DrawId = session.Draws?.LastOrDefault()?.Id
            };
        }

        public void Update(SessionDto sessionDto)
        {
            var session = _sessionRepository.GetById(sessionDto.Id);
            if (session == null) throw new ArgumentException("Session not found");
            session.StartTime = sessionDto.StartTime;
            session.EndTime = sessionDto.EndTime;
            _sessionRepository.Update(session);
        }
    }
}
