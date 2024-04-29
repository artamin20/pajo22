using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var products = _context.ProductModels.AsQueryable();
            var mainGroups = _context.GroupModels
                .Include(g => g.Subgroups)
                .ToList();

            if (!string.IsNullOrEmpty(nameFilter))
            {
                products = products.Where(p => p.Name.Contains(nameFilter));
            }

            if (!products.Any())
            {
                return View("NoProductsFound");
            }

            decimal? minPrice = products.Min(p => p.Price);
            decimal? maxPrice = products.Max(p => p.Price);

            if (minPriceFilter != null)
            {
                minPrice = Math.Max(minPrice ?? 0, minPriceFilter.Value);
            }

            if (maxPriceFilter != null)
            {
                maxPrice = Math.Min(maxPrice ?? decimal.MaxValue, maxPriceFilter.Value);
            }

            products = products.Where(p => p.Price >= minPrice && p.Price <= maxPrice);
            ViewBag.MainGroups = mainGroups;

            return View(products.ToList());
        }

        public IActionResult SubgroupProducts(string subgroupName)
        {
            var subgroupProducts = _context.ProductModels
                .Where(p => p.Subgroup.Name == subgroupName) // Use p.Subgroup.Name to compare with subgroupName
                .ToList();

            return View(subgroupProducts);
        }

    }
}
