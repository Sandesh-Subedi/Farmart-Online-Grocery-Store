using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Farmart.Models;

namespace Farmart.Controllers
{
    public class SignInController : Controller
    {
        private readonly ILogger<SignInController> _logger;
        public Farmart.Models.User? CurrentLogginUser { get; set; }

        public SignInController(ILogger<SignInController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost] // Holds data from Sign In form
        public IActionResult SignIn(Farmart.Models.SignIn signInModel)
        {
            string username = signInModel.Username;
            string password = signInModel.Password;

            Console.WriteLine($"Username: {username}, Password: {password}");

            if (Farmart.Models.SignIn.LoginWithData(username, password))
            {
                CurrentLogginUser = Farmart.Models.SignIn.getUserFromDatabase(username);
                Console.WriteLine(CurrentLogginUser.UserName.ToString());
            }
            else
            {
                // username or password is incorrect
                return View();
            }

            return View("Products");
        }

    }
}
