using System.Reflection.Metadata.Ecma335;
using Lotto3000App.DTOs;
using Lotto3000App.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lotto3000App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("all-users")]
        public ActionResult<List<UserDto>> GetAllUsers()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<UserDto> GetUserById(int id)
        {
            var user = _userService.GetAll().FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new Exception($"User with id {id} not found.");
            }
            return Ok(user);
        }
        [HttpGet("by-username/{username}")]
        public ActionResult<UserDto> GetUserByUsername(string username)
        {
            var user = _userService.GetAll().FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                throw new Exception($"User with username {username} not found.");
            }
            return Ok(user);
        }
        [HttpPost("add-user")]
        public ActionResult<UserDto> AddUser([FromBody] UserDto userDto)
        {
            //_userService.Add(userDto);
            //return CreatedAtAction(nameof(AddUser), new { id = userDto.Id }, userDto);
            var newUser = new UserDto 
            { 
                FirstName = userDto.FirstName, 
                LastName = userDto.LastName, 
                Username = userDto.Username, 
                Role = userDto.Role
            };
            _userService.Add(newUser);
            return StatusCode(StatusCodes.Status201Created, $"New user was successfully added.");
        }

        [HttpPut("update-user/{id}")]
        public ActionResult<UserDto> UpdateUser(int id, [FromBody] UserDto userDto)
        {
            var existingUser = _userService.GetAll().FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
            {
                throw new Exception($"User with id {id} not found.");
            }
            existingUser.FirstName = userDto.FirstName;
            existingUser.LastName = userDto.LastName;
            existingUser.Username = userDto.Username;
            existingUser.Role = userDto.Role;
            _userService.Update(existingUser);
            
            return StatusCode(StatusCodes.Status204NoContent, $"User with id {id} was successfully updated.");
        }

        [HttpDelete("delete-user/{id}")]
        public ActionResult DeleteUser(int id)
        {
            var existingUser = _userService.GetAll().FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
            {
                throw new Exception($"User with id {id} not found.");
            }
            _userService.Delete(existingUser.Id);
            return StatusCode(StatusCodes.Status204NoContent, $"User with id {id} was successfully deleted.");
        }
    }
}
