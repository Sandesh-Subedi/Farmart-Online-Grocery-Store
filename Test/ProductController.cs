using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyOnlineStore.Models;
using System.Linq;

namespace MyOnlineStore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string search)
        {
            var query = _context.Items.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(item =>
                    item.Name.Contains(search) ||
                    item.Description.Contains(search));
            }

            var filteredItems = query.ToList();
            return View(filteredItems);
        }
    }
}
