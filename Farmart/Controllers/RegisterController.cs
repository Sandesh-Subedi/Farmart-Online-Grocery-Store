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

        [HttpPost]
        public IActionResult Register(Farmart.Models.Register registerModel)
        {
            string firstName = registerModel.FirstName;
            string lastName = registerModel.LastName;
            string email = registerModel.Email;
            string username = registerModel.Username;
            string password = registerModel.Password;
            string confirmPassword = registerModel.ConfirmPassword;
            DateTime dateOfBirth = registerModel.DateOfBirth;


            if (password == confirmPassword)
            {
                User userToRegister = new User(username, password, email, firstName, lastName);

                if (userToRegister.RegisterUser())
                {
                    return View("Products");
                }
                else
                {
                    // username or email already exists
                }
            }
            else
            {
                // passwords do not match
            }

            return View();
        }


    }
}
