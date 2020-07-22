using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PKWebApp.Data;
using PKWebApp.Models;
using PKWebApp.Services;

namespace PKWebApp.Controllers
{
    public class HomeController : Controller
    {
       // private readonly ILogger<HomeController> _logger;
        private readonly IMailService _mailService;
        private readonly IPKRepository _repository;
      //  private readonly PKContext _context;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(IMailService mailService, IPKRepository repository)
        {
            _mailService = mailService;
            _repository = repository;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("privacy")]
        public IActionResult Privacy()
        {
            return View();
        }         
        [HttpGet("contact")]

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Send the email
                _mailService.SendMessage("my email", model.Subject, model.Message);
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();
            }
            else
            {
                // Show the error
            }
            return View();
        }

        [Authorize]
        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet("services")]
        public IActionResult Services()
        {
            var results = _repository.GetAllCoreServices();
            return View(results);
        }
    }
}
