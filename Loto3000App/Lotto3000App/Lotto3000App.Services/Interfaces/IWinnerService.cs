using Lotto3000App.Domain.Models;
using Lotto3000App.DTOs;

namespace Lotto3000App.Services.Interfaces
{
    public interface IWinnerService<Winner> where Winner : BaseEntity
    {
        List<WinnerDto> GetAll();
        WinnerDto GetById(int id);
        void Add(WinnerDto entity);
        void Update(WinnerDto entity);
        void Delete(int id);
    }
}
