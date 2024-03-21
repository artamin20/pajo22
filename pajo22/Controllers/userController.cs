using Microsoft.AspNetCore.Mvc;
using pajo22.Data;
using pajo22.Models;
using System.Linq;

namespace pajo22.Controllers
{
    public class userController : Controller
    {
        private readonly pajo22Context _context;

        public userController(pajo22Context context)
        {
            _context = context;
        }

        public IActionResult Index(string nameFilter, decimal? minPriceFilter, decimal? maxPriceFilter)
        {
            // Get all products from the database
            var products = _context.ProductModels.AsQueryable();

            // Apply filters if provided
            if (!string.IsNullOrEmpty(nameFilter))
            {
                products = products.Where(p => p.Name.Contains(nameFilter));
            }

            if (minPriceFilter != null)
            {
                products = products.Where(p => p.Price >= minPriceFilter);
            }

            if (maxPriceFilter != null)
            {
                products = products.Where(p => p.Price <= maxPriceFilter);
            }

            // Return the filtered list of products to the view
            return View(products.ToList());
        }
    }
}
