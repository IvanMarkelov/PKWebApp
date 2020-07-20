using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PKWebApp.Data;
using PKWebApp.Data.Entities;
using PKWebApp.Models;
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
        private readonly IMapper _mapper;

        public TicketsController(IPKRepository repository, ILogger<TicketsController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<Ticket>, IEnumerable<OrderViewModel>>(_repository.GetAllTickets()));
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

                if (ticket != null) return Ok(_mapper.Map<Ticket, OrderViewModel>(ticket));
                else return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Bad request: {ex}");
                return BadRequest("Failed to return the tickets");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]OrderViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newOrder = _mapper.Map<OrderViewModel, Ticket>(model);

                    if (newOrder.OrderDate == DateTime.MinValue)
                    {
                        newOrder.OrderDate = DateTime.Now;
                    }

                    _repository.AddEntity(newOrder);
                    if (_repository.SaveChanges())
                    {
                        var viewModel = _mapper.Map<Ticket, OrderViewModel>(newOrder);

                        return Created($"/api/tickets/{newOrder.Id}", _mapper.Map<Ticket, OrderViewModel>(newOrder));
                    }
                }
                else BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to send the ticket: {ex}");
            }
            return BadRequest("Failed to save the order");
        }
    }
}
