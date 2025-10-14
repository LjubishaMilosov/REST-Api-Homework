using Lotto3000App.Domain.Models;
using Lotto3000App.DTOs;

namespace Lotto3000App.Services.Interfaces
{
    public interface IUserService
    {
        List<UserDto> GetAll();
        UserDto GetById(int id);
        UserDto GetByUsername(string username);
        void Add(UserDto entity);
        void Update(UserDto entity);
        void Delete(int id);
    }
}
