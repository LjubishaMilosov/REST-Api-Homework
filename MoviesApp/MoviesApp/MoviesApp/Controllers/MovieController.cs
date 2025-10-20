using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Domaim.Enums;
using MoviesApp.Dtos;
using MoviesApp.Services.Interfaces;

namespace MoviesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("get-all")]
        [Authorize]
        public ActionResult<List<MovieDto>> GetAll()
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                if(identity == null)
                {
                    throw new ArgumentNullException("Identity is null");
                }
                if(!int.TryParse(identity.FindFirst("id")?.Value, out int userId))
                {
                    throw new Exception("Claim id does not exist");
                }
                return Ok(_movieService.GetAllMovies(userId));
                 
            } 
            catch (NullReferenceException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("filter")]
        [Authorize]
        public ActionResult<List<MovieDto>>FilterMovies(int? year, GenreEnum? genre)
        {
            try
            {
                //var identity = HttpContext.User.Identity as ClaimsIdentity;
                //if (identity == null)
                //{
                //    throw new ArgumentNullException("Identity is null");
                //}
                //if (!int.TryParse(identity.FindFirst("id")?.Value, out int userId))
                //{
                //    throw new Exception("Claim id does not exist");
                //}
                return Ok(_movieService.FilterMovies(year, genre));

            }
            catch (NullReferenceException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = Roles.Admin + "," + Roles.StandardUser)]
        [Authorize(Roles = Roles.Admin)]
        public IActionResult DeleteById(int id)
        {
            try
            {
                _movieService.DeleteMovie(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
