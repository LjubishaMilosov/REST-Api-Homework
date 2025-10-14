using Lotto3000App.DataAccess;
using Lotto3000App.Domain.Models;
using Lotto3000App.DTOs;
using Lotto3000App.Services.Implementation;
using Lotto3000App.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lotto3000App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        
    public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        //[HttpPost]
        //public IActionResult Create([FromBody] CreateTicketRequest request)
        //{
        //    if (request == null || request.Numbers == null || request.Numbers.Count != 7)
        //    {
        //        return BadRequest("Invalid ticket data. Exactly 7 numbers must be provided.");
        //    }
        //    var ticketDto = new TicketDto
        //    {
        //        UserId = request.UserId,
        //        Numbers = request.Numbers,
        //        SubmittedAt = DateTime.UtcNow,
        //        SessionId = request.SessionId
        //    };
        //    try
        //    {
        //        _ticketService.Add(ticketDto);
        //        return CreatedAtAction(nameof(GetById), new { id = ticketDto.Id }, ticketDto);
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpGet]
        public ActionResult<List<TicketDto>> GetAll() => Ok(_ticketService.GetAll());

        [HttpGet("{id}")]
        public ActionResult<TicketDto> GetById(int id)
        {
            var ticket = _ticketService.GetById(id);
            if (ticket == null) return NotFound();
            return Ok(ticket);
        }

        [HttpGet("user/{userId}")]
        public ActionResult<List<TicketDto>> GetByUserId(int userId) => Ok(_ticketService.GetByUserId(userId));

        [HttpPost]
        public IActionResult Add([FromBody] TicketDto ticketDto)
        {
            try
            {
                _ticketService.Add(ticketDto);
                return CreatedAtAction(nameof(GetById), new { id = ticketDto.Id }, ticketDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TicketDto ticketDto)
        {
            if (id != ticketDto.Id) return BadRequest("ID mismatch");
            try
            {
                _ticketService.Update(ticketDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _ticketService.Delete(id);
            return NoContent();
        }
    }
}
