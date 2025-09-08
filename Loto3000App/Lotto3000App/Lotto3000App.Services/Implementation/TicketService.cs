
using System.Net.Sockets;
using Lotto3000App.DataAccess.Implementation;
using Lotto3000App.Domain.Models;
using Lotto3000App.DTOs;
using Lotto3000App.Services.Interfaces;

namespace Lotto3000App.Services.Implementation
{
    public class TicketService : ITicketService<Ticket>
    {
        private readonly TicketRepository _ticketRepository;
        public TicketService(TicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public void Add(TicketDto ticketDto)
        {
            var ticket = new Ticket
            {
                UserId = ticketDto.UserId,
                Numbers = ticketDto.Numbers,
                SubmittedAt = ticketDto.SubmittedAt,
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
            if (ticket == null) return;
            ticket.Numbers = ticketDto.Numbers;
            ticket.SubmittedAt = ticketDto.SubmittedAt;
            ticket.SessionId = ticketDto.SessionId;
            _ticketRepository.Update(ticket);
        }
    }
}
