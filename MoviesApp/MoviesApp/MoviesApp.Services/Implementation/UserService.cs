using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.IdentityModel.Tokens;
using MoviesApp.DataAccess.Interfaces;
using MoviesApp.Domaim.Models;
using MoviesApp.Dtos;
using MoviesApp.Services.Interfaces;

namespace MoviesApp.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string Login(LoginUserDto loginUserDto)
        {
            throw new NotImplementedException();
        }

        public void RegisterUser(RegisterUserDto registerUserDto)
        {
            if (registerUserDto == null)
            {
                throw new NullReferenceException("Model cannot be null");
            }
            if (string.IsNullOrEmpty(registerUserDto.FirstName) || string.IsNullOrEmpty(registerUserDto.LastName))
            {
                throw new NullReferenceException("First name and last name are required");
            }
            if (string.IsNullOrEmpty(registerUserDto.Username))
            {
                throw new Exception("Username is required");
            }
            if (string.IsNullOrEmpty(registerUserDto.Password) || string.IsNullOrEmpty(registerUserDto.ConfirmPassword))
            {
                throw new Exception("Password and confirm password are required");
            }
            if (registerUserDto.Password != registerUserDto.ConfirmPassword)
            {
                throw new Exception("Password and confirm password do not match");
            }
            if (_userRepository.GetUserByUsername(registerUserDto.Username) != null)
            {
                throw new Exception("User with that Username already exists");
            }

            string strongPasswordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
            if (!Regex.IsMatch(registerUserDto.Password, strongPasswordRegex))
            {
                throw new DataException("Password is not strong enough. It must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one number and one special character.");
            }

            // create new user
            User user = new User
            {
                FirstName = registerUserDto.FirstName,
                LastName = registerUserDto.LastName,
                Username = registerUserDto.Username,
                Password = Generatehash(registerUserDto.Password)
            };

            _userRepository.Add(user);
        }
        private string Generatehash(string password)
        {
            using (var md5Hash = MD5.Create())
            {
                var passwordbytes = Encoding.ASCII.GetBytes(password);
                var hashedBytes = md5Hash.ComputeHash(passwordbytes);
                var hashed = Encoding.ASCII.GetString(hashedBytes);

                return hashed;
            }
        }
    }
}

