using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
            if(loginUserDto == null)
            {
                throw new NullReferenceException("Model cannot be null");
            }
            if(string.IsNullOrEmpty(loginUserDto.Username) || string.IsNullOrEmpty(loginUserDto.Password))
            {
                throw new NullReferenceException("Username and password are required");
            }

            var hashedPassword = Generatehash(loginUserDto.Password);
            var userDb = _userRepository.GetAll().FirstOrDefault(u => u.Username == loginUserDto.Username && u.Password == hashedPassword);
            if(userDb == null)
            {
                throw new DataException("Wrong username or password");
            }

            // generate JWT token that we will use for authntication/authorization

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var secretKey = Encoding.ASCII.GetBytes("Our secret secret secret secret secret secret secret secret key");

            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(2),
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, loginUserDto.Username),
                    new Claim("id", userDb.Id.ToString()),
                    new Claim("userFullName", $"{userDb.FirstName} {userDb.LastName}")

                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            string tokenString = jwtSecurityTokenHandler.WriteToken(token);

            return tokenString;
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

