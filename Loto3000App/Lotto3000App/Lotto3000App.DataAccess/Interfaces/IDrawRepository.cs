using Lotto3000App.Domain.Models;

namespace Lotto3000App.DataAccess.Interfaces
{
    public interface IDrawRepository : IRepository<Draw>
    {
       Draw GetDrawBySessionId(int sessionId);
    }
}
