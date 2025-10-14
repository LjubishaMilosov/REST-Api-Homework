using Lotto3000App.Domain.Models;
using Lotto3000App.DTOs;

namespace Lotto3000App.Services.Interfaces
{
    public interface IWinnerService
    {
        List<WinnerDto> GetAll();
        WinnerDto GetById(int id);
        List<WinnerDto> GetWinnersByDrawId(int drawId);
        void Add(WinnerDto entity);
        void Update(WinnerDto entity);
        void Delete(int id);
    }
}
