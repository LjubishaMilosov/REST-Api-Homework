
using Lotto3000App.Domain.Models;

namespace Lotto3000App.DataAccess.Interfaces
{
    public interface IWinnerRepository : IRepository<Winner>
    {
        List<Winner> GetWinnersByDrawId(int drawId);
    }
}
