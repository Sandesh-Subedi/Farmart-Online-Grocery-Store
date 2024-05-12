using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Farmart.Models;

namespace Farmart.Controllers
{
    public class AboutUsController : Controller
    {
        private readonly ILogger<AboutUsController> _logger;
        public Farmart.Models.User? CurrentLogginUser { get; set; }

        public AboutUsController(ILogger<AboutUsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
