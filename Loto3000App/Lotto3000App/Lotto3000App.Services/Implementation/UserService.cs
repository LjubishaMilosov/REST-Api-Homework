using Lotto3000App.DataAccess.Interfaces;
using Lotto3000App.Domain.Enums;
using Lotto3000App.Domain.Models;
using Lotto3000App.DTOs;
using Lotto3000App.Services.Interfaces;

namespace Lotto3000App.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Add(UserDto userDto)
        {
            if (userDto == null)
                throw new ArgumentNullException(nameof(userDto), "User cannot be null");
            if (string.IsNullOrWhiteSpace(userDto.Username))
                throw new ArgumentException("Username cannot be empty");
            if (string.IsNullOrWhiteSpace(userDto.FirstName))
                throw new ArgumentException("First name is required");
            if (string.IsNullOrWhiteSpace(userDto.LastName))
                throw new ArgumentException("Last name is required");

            var user = new User
            {
                Username = userDto.Username,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Role = Enum.TryParse<RoleEnum>(userDto.Role, out var role) ? role : RoleEnum.Player
         //     Role = Enum.TryParse(userDto.Role, out RoleEnum role) ? role : RoleEnum.Player
            //};
        };
            _userRepository.Add(user);
            userDto.Id = user.Id;
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
            if (user == null)
            {
                throw new Exception("User not found");
            }
            ;
            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role.ToString()
            };
        }

        public UserDto GetByUsername(string username)
        {
            var user = _userRepository.GetByUsername(username);
            if (user == null)
                throw new Exception("User not found");
            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role.ToString()
            };
        }

        public void Update(UserDto userDto)
        {
            var user = _userRepository.GetById(userDto.Id);
            if (user == null) throw new ArgumentException("User not found");
            user.Username = userDto.Username;
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.Role = Enum.TryParse<RoleEnum>(userDto.Role, out var role) ? role : user.Role;
            _userRepository.Update(user);
      //    user.Role = Enum.TryParse(userDto.Role, out RoleEnum role) ? role : user.Role;
     //     _userRepository.Update(user);
        }
    }
}
