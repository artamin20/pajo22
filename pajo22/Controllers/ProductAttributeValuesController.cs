using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pajo22.Data;
using pajo22.Models;

namespace pajo22.Controllers
{
    public class ProductAttributeValuesController : Controller
    {
        private readonly pajo22Context _context;

        public ProductAttributeValuesController(pajo22Context context)
        {
            _context = context;
        }

        // GET: ProductAttributeValues/Create
        public IActionResult Create(int? productId)
        {
            if (productId == null)
            {
                return NotFound();
            }

            // Retrieve product details based on productId and its associated subgroup attributes
            var attributes = _context.AttributeValues
                .Include(av => av.Attribute)
                .Where(av => av.ProductModelId == productId)
                .ToList();

            if (attributes.Count == 0)
            {
                return NotFound(); // Handle the case where no attributes are found
            }

            ViewBag.ProductId = productId;
            return View(attributes);
        }


        // POST: ProductAttributeValues/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int productId, List<AttributeValues> attributeValues)
        {
            if (ModelState.IsValid)
            {
                // Save the attribute values to the database
                foreach (var attributeValue in attributeValues)
                {
                    attributeValue.ProductModelId = productId;
                    _context.Add(attributeValue);
                }
                _context.SaveChanges();

                // Redirect to the product detail page or any other relevant page
                return RedirectToAction("Details", "ProductModels", new { id = productId });
            }
            return View(attributeValues);
        }
    }
}
