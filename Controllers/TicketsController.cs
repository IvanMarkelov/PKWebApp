using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PKWebApp.Data;
using PKWebApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKWebApp.Controllers
{
    [Route("api/[Controller]")]
    public class TicketsController: Controller
    {
        private readonly IPKRepository _repository;
        private readonly ILogger<TicketsController> _logger;

        public TicketsController(IPKRepository repository, ILogger<TicketsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAllTickets());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Bad request: {ex}");
                return BadRequest("Failed to return the tickets");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var ticket = _repository.GetTicketById(id);

                if (ticket != null) return Ok(ticket);
                else return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Bad request: {ex}");
                return BadRequest("Failed to return the tickets");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Ticket ticket)
        {
            try
            {
                return Ok(ticket);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to send the ticket: {ex}");
                return BadRequest("Failed to send the ticket");
            }
        }
    }
}
