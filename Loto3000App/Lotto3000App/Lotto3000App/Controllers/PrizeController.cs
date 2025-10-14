using Lotto3000App.DTOs;
using Lotto3000App.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lotto3000App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrizeController : ControllerBase
    {
        private readonly IPrizeService _prizeService;
        public PrizeController(IPrizeService prizeService)
        {
            _prizeService = prizeService;
        }

        [HttpGet]
        public ActionResult<List<PrizeDto>> GetAll() => Ok(_prizeService.GetAll());

        [HttpGet("{id}")]
        public ActionResult<PrizeDto> GetById(int id)
        {
            var prize = _prizeService.GetById(id);
            if (prize == null) return NotFound();
            return Ok(prize);
        }

        [HttpGet("tier/{tier}")]
        public ActionResult<PrizeDto> GetPrizeByTier(int tier)
        {
            var prize = _prizeService.GetPrizeByTier(tier);
            if (prize == null) return NotFound();
            return Ok(prize);
        }

        [HttpPost]
        public IActionResult Add([FromBody] PrizeDto prizeDto)
        {
            _prizeService.Add(prizeDto);
            return CreatedAtAction(nameof(GetById), new { id = prizeDto.Id }, prizeDto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] PrizeDto prizeDto)
        {
            if (id != prizeDto.Id) return BadRequest("ID mismatch");
            _prizeService.Update(prizeDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _prizeService.Delete(id);
            return NoContent();
        }
    }
}
