using Lotto3000App.Domain.Models;

namespace Lotto3000App.DataAccess.Interfaces
{
    public interface IPrizeRepository : IRepository<Prize>
    {
        Prize GetPrizeByTier(int tier);
    }
}
