using Lotto3000App.Domain.Models;
using Lotto3000App.DTOs;

namespace Lotto3000App.Services.Interfaces
{
    public interface ITicketService
    {
        List<TicketDto> GetAll();
        TicketDto GetById(int id);
        List<TicketDto> GetByUserId(int userId);
        void Add(TicketDto entity);
        void Update(TicketDto entity);
        void Delete(int id);
    }
}
