
using System.Security.Claims;
using Lotto3000App.Domain.Models;
using Lotto3000App.DTOs;
using Lotto3000App.Services.Implementation;
using Lotto3000App.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lotto3000App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrawController : ControllerBase
    {
        private readonly IDrawService _drawService;
        public DrawController(IDrawService drawsService)
        {
            _drawService = drawsService;
        }


        [HttpGet("all-draws")]
        public ActionResult<List<DrawDto>> GetAll()
        {
            var draws = _drawService.GetAll();
            if (draws == null || draws.Count == 0)
            {
                return NotFound("No draws found.");
            }
                return Ok(draws);
        }

        [HttpGet("{id}")]
        public ActionResult<DrawDto> GetById(int id)
        {
            var draw = _drawService.GetById(id);
            if (draw == null)
            {
                return NotFound();
            }
            return Ok(draw);
        }

        [HttpGet("session/{sessionId}")]
        public ActionResult<DrawDto> GetDrawBySessionId(int sessionId)
        {
            var draw = _drawService.GetDrawBySessionId(sessionId);
            if (draw == null)
            {
                throw new Exception($"User with username {sessionId} not found.");
            }
            return Ok(draw);
        }
        [HttpPost("add-draw")]
        public IActionResult Add([FromBody] DrawDto drawDto)
        {
            try
            {
                _drawService.Add(drawDto);
                return CreatedAtAction(nameof(GetById), new { id = drawDto.Id }, drawDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDraw(int id, [FromBody] DrawDto drawDto)
        {
            if (id != drawDto.Id) return BadRequest("ID mismatch");
            _drawService.Update(drawDto);
            return NoContent();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteDraw(int id)
        {
            _drawService.Delete(id);
            return NoContent();
        }

        [HttpPost("start")]
        public IActionResult StartDraw(int adminUserId, int sessionId)
        {
            var draw = _drawService.StartDraw(adminUserId, sessionId);
            return Ok(draw);
        }


        //[HttpPost("start")]
        //[Authorize(Roles = "Admin")]
        //public async Task<IActionResult> StartDraw()
        //{
        //    var adminId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        //    var draw = await _drawService.StartDrawAsync(adminId);
        //    return Ok(new { draw.Id, draw.DrawnNumbers, draw.StartedAt });
        //}
    }
}