
using Lotto3000App.Domain.Models;

namespace Lotto3000App.DataAccess.Interfaces
{
    public interface IWinnerRepository<Winner> where Winner : BaseEntity
    {
        List<Winner> GetAll();
        Winner GetById(int id);
        void Add(Winner entity);
        void Update(Winner entity);
        void Delete(Winner entity);
    }
}
