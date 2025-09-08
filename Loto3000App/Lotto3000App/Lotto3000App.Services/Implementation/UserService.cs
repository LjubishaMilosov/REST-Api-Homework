using Lotto3000App.DataAccess.Interfaces;
using Lotto3000App.Domain.Enums;
using Lotto3000App.Domain.Models;
using Lotto3000App.DTOs;
using Lotto3000App.Services.Interfaces;

namespace Lotto3000App.Services.Implementation
{
    public class UserService : IUserService<User>
    {
        private readonly IUserRepository<User> _userRepository;
        public UserService(IUserRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public void Add(UserDto entity)
        {
            var user = new User
            {
                Username = entity.Username,
                Role = Enum.TryParse<RoleEnum>(entity.Role, out var role) ? role : RoleEnum.Player
            };
            _userRepository.Add(user);
            entity.Id = user.Id;
        }

        public void Delete(int id)
        {
            {
                var user = _userRepository.GetById(id);
                if (user != null)
                    _userRepository.Delete(user);
            }
        }

        public List<UserDto> GetAll()
        {
            return _userRepository.GetAll()
                 .Select(u => new UserDto
                 {
                     Id = u.Id,
                     Username = u.Username,
                     Role = u.Role.ToString()
                 })
                 .ToList();
        }

        public UserDto GetById(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null) return null;
            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role.ToString()
            };
        }

        public void Update(UserDto entity)
        {
            var user = new User
            {
                Username = entity.Username,
                Role = Enum.TryParse<RoleEnum>(entity.Role, out var role) ? role : RoleEnum.Player
            };
            _userRepository.Add(user);
            entity.Id = user.Id;
        }
    }
}
