using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        public MvcMovie.Models.User? CurrentLogginUser { get; set; }

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string searchTerm)
        {
            List<Product> products;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                // Perform search if search term is provided
                products = SearchBar.SearchProducts(searchTerm);
            }
            else
            {
                // Load all products if no search term is provided
                products = DisplayItems.getAllItems();
            }

            // Pass the search term to the view
            ViewBag.SearchTerm = searchTerm;

            return View(products);
        }


      



        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
