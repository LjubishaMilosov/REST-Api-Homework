using Lotto3000App.DTOs;
using Lotto3000App.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lotto3000App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _sessionService;
        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }
        [HttpGet("all-sessions")]
        public ActionResult<List<SessionDto>> GetAll()
        {
            return Ok(_sessionService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<SessionDto> GetById(int id)
        {
            var session = _sessionService.GetById(id);
            if (session == null) return NotFound();
            return Ok(session);
        }
        [HttpGet("active")]
        public ActionResult<SessionDto> GetActiveSession()
        {
            var session = _sessionService.GetActiveSession();
            if (session == null) return NotFound();
            return Ok(session);
        }
        [HttpPost]
        public IActionResult Create([FromBody] SessionDto sessionDto)
        {
            if (sessionDto == null)
            {
                return BadRequest("Session data is required.");
            }
            try
            {
                _sessionService.Add(sessionDto);
                return CreatedAtAction(nameof(GetById), new { id = sessionDto.Id }, sessionDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] SessionDto sessionDto)
        {
            if (sessionDto == null || sessionDto.Id != id)
            {
                return BadRequest("Invalid session data.");
            }
            try
            {
                _sessionService.Update(sessionDto);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _sessionService.Delete(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
