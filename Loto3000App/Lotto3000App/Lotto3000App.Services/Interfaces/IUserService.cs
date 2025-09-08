using Lotto3000App.Domain.Models;
using Lotto3000App.DTOs;

namespace Lotto3000App.Services.Interfaces
{
    public interface IUserService<User> where User : BaseEntity
    {
        List<UserDto> GetAll();
        UserDto GetById(int id);
        void Add(UserDto entity);
        void Update(UserDto entity);
        void Delete(int id);
    }
}
