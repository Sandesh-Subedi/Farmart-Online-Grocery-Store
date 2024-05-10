using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Farmart.Models;

namespace Farmart.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public Farmart.Models.User? CurrentLogginUser { get; set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult AboutUs()
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

            Console.WriteLine($"First Name: {firstName}, Last Name: {lastName}, Email: {email}");
            Console.WriteLine($"Username: {username}, Password: {password}, Confirm Password: {confirmPassword}, Date of Birth: {dateOfBirth}");

            // TODO: Implement register() 
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
