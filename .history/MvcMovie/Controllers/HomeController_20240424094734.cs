using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;


namespace MvcMovie.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

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
        bool result = MvcMovie.Models.SignIn.LoginWithData("johnfarmer", "password123");
        Console.WriteLine(result);
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


    public IActionResult Products()
    {
        return View();
    }

    public IActionResult AboutUs()
    {
        return View();
    }

    public IActionResult Cart()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SignIn(SignIn signInModel) // Accepts the SignIn model as parameter
    {
        string username = signInModel.Username;
        string password = signInModel.Password;
        // Process the sign-in data here
        // You can access signInModel.Username and signInModel.Password

        Console.WriteLine("", username, password);

        // Redirect to appropriate action after sign-in
        return View();

    }




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
