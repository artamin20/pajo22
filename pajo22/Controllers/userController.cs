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

                // Fetch attribute names
                var attributeNames = _context.Attributes
                    .Select(a => a.AttributeName)
                    .Distinct()
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
                ViewBag.AttributeNames = attributeNames;

                return View(products.ToList());
            }


            public IActionResult SubgroupProducts(string subgroupName)
            {
                var subgroupProducts = _context.ProductModels
                    .Where(p => p.Subgroup.Name == subgroupName) // Use p.Subgroup.Name to compare with subgroupName
                    .ToList();

                return View(subgroupProducts);
            }
            [HttpPost]
            public IActionResult AttributeSearch(string attributeName, string attributeValue)
            {
                // Find the attribute 
                var attribute = _context.Attributes.FirstOrDefault(a => a.AttributeName == attributeName);
                if (attribute == null)
                {
                    // Handle the case when the attribute name is not found
                    return View("NoProductsFound");
                }

                // Redirect to the attribute search URL with attribute name and value
                return RedirectToAction("AttributeSearch", new { attributeValueName = attributeValue, attributeId = attribute.AttributeID });
            }

        public IActionResult AttributeSearch(string attributeValueName, int attributeId)
        {
            // Retrieve attribute values based on the search criteria
            var attributeValues = _context.AttributeValues
                .Include(av => av.Attribute)
                .Include(av => av.ProductModel)
                .Where(av => av.AttributeID == attributeId && av.Value.Contains(attributeValueName))
                .ToList();

            // If no matches found, try with partial matches


            return View(attributeValues);
        }



    }
}
