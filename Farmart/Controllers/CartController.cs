using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Farmart.Models;

namespace Farmart.Controllers
{
    public class CartController : Controller
    {
        private readonly ILogger<CartController> _logger;
        public Farmart.Models.User? CurrentLogginUser { get; set; }

        public CartController(ILogger<CartController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
