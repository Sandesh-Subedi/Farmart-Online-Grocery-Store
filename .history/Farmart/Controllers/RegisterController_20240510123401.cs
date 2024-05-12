using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Farmart.Models;

namespace Farmart.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ILogger<RegisterController> _logger;
        public Farmart.Models.User? CurrentLogginUser { get; set; }

        public RegisterController(ILogger<RegisterController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
