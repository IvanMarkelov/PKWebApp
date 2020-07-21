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
    public class OrdersController: Controller
    {
        private readonly IPKRepository _repository;
        private readonly ILogger<OrdersController> _logger;
        private readonly IMapper _mapper;

        public OrdersController(IPKRepository repository, ILogger<OrdersController> logger, IMapper mapper)
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
                return Ok(_mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(_repository.GetAllTickets()));
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

                if (ticket != null) return Ok(_mapper.Map<Order, OrderViewModel>(ticket));
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
                    var newOrder = _mapper.Map<OrderViewModel, Order>(model);

                    if (newOrder.OrderDate == DateTime.MinValue)
                    {
                        newOrder.OrderDate = DateTime.Now;
                    }

                    _repository.AddEntity(newOrder);
                    if (_repository.SaveChanges())
                    {
                        var viewModel = _mapper.Map<Order, OrderViewModel>(newOrder);

                        return Created($"/api/tickets/{newOrder.Id}", _mapper.Map<Order, OrderViewModel>(newOrder));
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
