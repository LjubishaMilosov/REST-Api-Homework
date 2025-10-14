using Lotto3000App.Domain.Models;
using Lotto3000App.DTOs;

namespace Lotto3000App.Services.Interfaces
{
    public interface IDrawService
    {
        List<DrawDto> GetAll();
        DrawDto GetById(int id);
        DrawDto GetDrawBySessionId(int sessionId);
        void Add(DrawDto entity);
        void Update(DrawDto entity);
        void Delete(int id);
        DrawDto StartDraw(int adminUserId, int sessionId); // Custom business logic to be added
    }
}
