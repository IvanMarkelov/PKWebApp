using Microsoft.AspNetCore.Cors.Infrastructure;
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
    public class ServicesController : Controller
    {
        private readonly IPKRepository _repository;
        private readonly ILogger<ServicesController> _logger;

        public ServicesController(IPKRepository repository, ILogger<ServicesController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAllCoreServices());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get services: {ex}");
                return BadRequest("Failed to get services.");
            }
        }
    }
}
