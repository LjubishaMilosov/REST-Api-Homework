using Lotto3000App.Domain.Models;
using Lotto3000App.DTOs;

namespace Lotto3000App.Services.Interfaces
{
    public interface IDrawService<Draw> where Draw : BaseEntity
    {
        List<DrawDto> GetAll();
        DrawDto GetById(int id);
        void Add(DrawDto entity);
        void Update(DrawDto entity);
        void Delete(int id);
    }
}
