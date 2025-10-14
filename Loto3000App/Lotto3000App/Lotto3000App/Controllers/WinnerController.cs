using Lotto3000App.DTOs;
using Lotto3000App.Services.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Lotto3000App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WinnerController : ControllerBase
    {
        private readonly IWinnerService _winnerService;
        public WinnerController(IWinnerService winnerService)
        {
            _winnerService = winnerService;
        }

        [HttpGet]
        public ActionResult<List<WinnerDto>> GetAll() => Ok(_winnerService.GetAll());

        [HttpGet("{id}")]
        public ActionResult<WinnerDto> GetById(int id)
        {
            var winner = _winnerService.GetById(id);
            if (winner == null) return NotFound();
            return Ok(winner);
        }

        [HttpGet("draw/{drawId}")]
        public ActionResult<List<WinnerDto>> GetWinnersByDrawId(int drawId) => Ok(_winnerService.GetWinnersByDrawId(drawId));

        [HttpPost]
        public IActionResult Add([FromBody] WinnerDto winnerDto)
        {
            _winnerService.Add(winnerDto);
            return CreatedAtAction(nameof(GetById), new { id = winnerDto.Id }, winnerDto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] WinnerDto winnerDto)
        {
            if (id != winnerDto.Id) return BadRequest("ID mismatch");
            _winnerService.Update(winnerDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _winnerService.Delete(id);
            return NoContent();
        }

    }
}