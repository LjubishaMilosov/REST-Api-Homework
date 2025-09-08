using Lotto3000App.Domain.Models;

namespace Lotto3000App.DataAccess.Interfaces
{
    public interface IDrawRepository<Draw> where Draw : BaseEntity
    {
        List<Draw> GetAll();
        Draw GetById(int id);
        void Add(Draw entity);
        void Update(Draw entity);
        void Delete(Draw entity);
    }
}
