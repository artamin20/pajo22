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
            // گرفتن محصولات
            var products = _context.ProductModels.AsQueryable();

            // فیلتر ها 
            if (!string.IsNullOrEmpty(nameFilter))
            {
                products = products.Where(p => p.Name.Contains(nameFilter));
            }

            // درصورتی که محصولی پیدا نشد
            if (!products.Any())
            {
                
                return View("NoProductsFound");
            }

            // مین و ماکس بودن
            // مین و ماکس بودن
            decimal? minPrice = products.Min(p => p.Price);
            decimal? maxPrice = products.Max(p => p.Price);

            // چک کردن رنج با قیمت
            if (minPriceFilter != null)
            {
                minPrice = Math.Max(minPrice ?? 0, minPriceFilter.Value);
            }

            if (maxPriceFilter != null)
            {
                maxPrice = Math.Min(maxPrice ?? decimal.MaxValue, maxPriceFilter.Value);
            }



            // فیلتر بر اساس قیمت
            products = products.Where(p => p.Price >= minPrice && p.Price <= maxPrice);

            return View(products.ToList());
        }
    }
}
