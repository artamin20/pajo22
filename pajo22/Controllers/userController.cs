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
            // Get all products
            var products = _context.ProductModels.AsQueryable();

            // Apply name filter if provided
            if (!string.IsNullOrEmpty(nameFilter))
            {
                products = products.Where(p => p.Name.Contains(nameFilter));
            }

            // Find minimum and maximum prices
            decimal minPrice = products.Min(p => p.Price);
            decimal maxPrice = products.Max(p => p.Price);

            // If price filters are provided, ensure they are within the range of product prices
            if (minPriceFilter != null)
            {
                minPrice = Math.Max(minPrice, (decimal)minPriceFilter);
            }

            if (maxPriceFilter != null)
            {
                maxPrice = Math.Min(maxPrice, (decimal)maxPriceFilter);
            }

            // Filter products based on price range
            products = products.Where(p => p.Price >= minPrice && p.Price <= maxPrice);

            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;

            return View(products.ToList());
        }
    }
}
