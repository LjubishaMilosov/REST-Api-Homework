
using System.Net.Sockets;
using Lotto3000App.DataAccess.Implementation;
using Lotto3000App.DataAccess.Interfaces;
using Lotto3000App.Domain.Models;
using Lotto3000App.DTOs;
using Lotto3000App.Services.Interfaces;

namespace Lotto3000App.Services.Implementation
{
    public class TicketService : ITicketService<Ticket>
    {
        private readonly ITicketRepository<Ticket> _ticketRepository;
        private readonly IUserRepository<User> _userRepository;
        public TicketService(ITicketRepository<Ticket> ticketRepository, IUserRepository<User> userRepository)
        {
            _ticketRepository = ticketRepository;
            _userRepository = userRepository;
        }
        public void Add(TicketDto ticketDto)
        {
            if (ticketDto == null)
                throw new ArgumentNullException(nameof(ticketDto), "Ticket cannot be null");
            if (ticketDto.Numbers == null || ticketDto.Numbers.Count != 7)
                throw new ArgumentException("Exactly 7 numbers must be selected");
            if (ticketDto.Numbers.Any(n => n < 1 || n > 37))
                throw new ArgumentException("Numbers must be between 1 and 37");
            if (ticketDto.Numbers.Distinct().Count() != 7)
                throw new ArgumentException("Numbers must be unique");

            var user = _userRepository.GetById(ticketDto.UserId);
            if (user == null)
                throw new ArgumentException($"User with id {ticketDto.UserId} does not exist");

            var ticket = new Ticket
            {
                UserId = ticketDto.UserId,
                Numbers = ticketDto.Numbers,
                SubmittedAt = DateTime.UtcNow,
                SessionId = ticketDto.SessionId
            };
            _ticketRepository.Add(ticket);
            ticketDto.Id = ticket.Id;
        }

        public void Delete(int id)
        {
            var ticket = _ticketRepository.GetById(id);
            if (ticket != null)
                _ticketRepository.Delete(ticket);
        }

        public List<TicketDto> GetAll()
        {
            return _ticketRepository.GetAll()
                .Select(t => new TicketDto
                {
                    Id = t.Id,
                    UserId = t.UserId,
                    Numbers = t.Numbers,
                    SubmittedAt = t.SubmittedAt,
                    SessionId = t.SessionId
                })
                .ToList();
        }

        public TicketDto GetById(int id)
        {
            var ticket = _ticketRepository.GetById(id);
            if (ticket == null)
            {
                throw new Exception($"Ticket with ID {id} not found.");
            }
            ;
            return new TicketDto
            {
                Id = ticket.Id,
                UserId = ticket.UserId,
                Numbers = ticket.Numbers,
                SubmittedAt = ticket.SubmittedAt,
                SessionId = ticket.SessionId
            };
        }

        public void Update(TicketDto ticketDto)
        {
            var ticket = _ticketRepository.GetById(ticketDto.Id);
            if (ticket == null) throw new ArgumentException("Ticket not found");
            ticket.Numbers = ticketDto.Numbers;
            ticket.SubmittedAt = ticketDto.SubmittedAt;
            ticket.SessionId = ticketDto.SessionId;
            _ticketRepository.Update(ticket);
        }
    }
}
