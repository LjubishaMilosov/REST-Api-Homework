using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeworkClassTwoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet("getAllUsers")]
        public ActionResult<List<string>> GetAllUsers()
        {
            return Ok(StaticDb.Users);
        }

        [HttpGet("userid/{index}")]

        public ActionResult<string> GetByUserId(int index)
        {
            try
            {
                if(index < 0)
                {
                    return BadRequest("The index has negative value");
                }
                if(index >= StaticDb.Users.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"There is no resource on index {index}");
                }
                return Ok(StaticDb.Users[index]);

            }
            catch (Exception e) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Error occured.Please contact your administrator.");
            }
        }
    }
}
