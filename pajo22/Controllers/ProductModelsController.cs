using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pajo22.Data;
using pajo22.Models;

namespace pajo22.Controllers
{
    public class ProductModelsController : Controller
    {
        private readonly pajo22Context _context;

        public ProductModelsController(pajo22Context context)
        {
            _context = context;
        }

        // GET: ProductModels
        public async Task<IActionResult> Index()
        {
            // کرفتن زیرگروه های فعال
            var activeSubgroupIds = await _context.SubgroupModels
                .Where(s => s.Status == SubgroupStatus.Active)
                .Select(s => s.Id)
                .ToListAsync();

            
            var products = await _context.ProductModels
                .Include(p => p.Subgroup)
                .ToListAsync();

            // غیرفعال کردن محصولاتی که زیرگروه های آن غیر فعال شده
            foreach (var product in products)
            {
                if (product.Subgroup != null && !activeSubgroupIds.Contains(product.SubgroupId))
                {
                    product.Status = ProductStatus.Inactive;
                }
            }

            // Save changes to the database
            await _context.SaveChangesAsync();

            return View(products);
        }



        // GET: ProductModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productModels = await _context.ProductModels
                .Include(p => p.Subgroup)
                .Include(p => p.AttributeValues) // Include the attribute values
                .ThenInclude(av => av.Attribute) // Include the attribute related to each attribute value
                .FirstOrDefaultAsync(m => m.Id == id);

            if (productModels == null)
            {
                return NotFound();
            }

            return View(productModels);
        }

        // GET: ProductModels/Create
        public IActionResult Create()
        {
            ViewData["SubgroupId"] = new SelectList(_context.SubgroupModels, "Id", "Name");
            return View();
        }

        // POST: ProductModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Image,Description,SubgroupId,color")] ProductModels productModels, IFormFile? productImage)
        {
            if (ModelState.IsValid)
            {
                if (productImage != null && productImage.Length > 0)
                {
                    var allowedExtensions = new[]
                    {
                ".jpg", ".jpeg", ".png"
            };

                    var filename = Path.GetFileName(productImage.FileName);
                    var ext = Path.GetExtension(filename);
                    if (allowedExtensions.Contains(ext))
                    {
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", filename);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await productImage.CopyToAsync(stream);
                        }

                        productModels.Image = "/Images/" + filename;
                    }
                    else
                    {
                        ModelState.AddModelError("productImage", "Invalid file type. Only JPEG and PNG are allowed.");
                        ViewData["SubgroupId"] = new SelectList(_context.Set<SubgroupModels>(), "Id", "", productModels.SubgroupId);
                        return View(productModels);
                    }
                }

                _context.Add(productModels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["SubgroupId"] = new SelectList(_context.Set<SubgroupModels>(), "Id", "Name", productModels.SubgroupId);
            return View(productModels);
        }



        // GET: ProductModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productModels = await _context.ProductModels.FindAsync(id);
            if (productModels == null)
            {
                return NotFound();
            }
            ViewData["SubgroupId"] = new SelectList(_context.SubgroupModels, "Id", "Name", productModels.SubgroupId);
            return View(productModels);
        }
        // POST: ProductModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Image,Description,SubgroupId,Status")] ProductModels productModels, IFormFile? productImage)
        {
            if (id != productModels.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingProduct = await _context.ProductModels.FindAsync(id);

                    if (productImage != null && productImage.Length > 0)
                    {
                        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
                        var filename = Path.GetFileName(productImage.FileName);
                        var ext = Path.GetExtension(filename);
                        if (allowedExtensions.Contains(ext))
                        {
                            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", filename);
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                await productImage.CopyToAsync(stream);
                            }
                            productModels.Image = "/Images/" + filename;
                        }
                        else
                        {
                            ModelState.AddModelError("productImage", "Invalid file type. Only JPEG and PNG are allowed.");
                            ViewData["SubgroupId"] = new SelectList(_context.Set<SubgroupModels>(), "Id", "Name", productModels.SubgroupId);
                            return View(productModels);
                        }
                    }
                    else
                    {
                        productModels.Image = existingProduct.Image;
                    }

                    // انتخاب وضعیت محصول
                    existingProduct.Status = productModels.Status;

                    _context.Entry(existingProduct).CurrentValues.SetValues(productModels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductModelsExists(productModels.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubgroupId"] = new SelectList(_context.SubgroupModels, "Id", "Name", productModels.SubgroupId);
            return View(productModels);
        }
        // GET: ProductModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productModels = await _context.ProductModels
                .Include(p => p.Subgroup)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productModels == null)
            {
                return NotFound();
            }

            return View(productModels);
        }

        // POST: ProductModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productModels = await _context.ProductModels.FindAsync(id);
            if (productModels != null)
            {
                _context.ProductModels.Remove(productModels);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductModelsExists(int id)
        {
            return _context.ProductModels.Any(e => e.Id == id);
        }
        private async Task<ProductModels> GetProductDetails(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var productModels = await _context.ProductModels
                .Include(p => p.Subgroup)
                .Include(p => p.AttributeValues)
                    .ThenInclude(av => av.Attribute)
                .FirstOrDefaultAsync(m => m.Id == id);

            return productModels;
        }

        // GET: ProductModels/AddAttributeValues/5
        public async Task<IActionResult> AddAttributeValues(int? productId)
        {
            if (productId == null)
            {
                return NotFound();
            }

            var product = await GetProductDetails(productId);

            if (product == null)
            {
                return NotFound();
            }

            // Retrieve the product's subgroup
            var subgroup = await _context.SubgroupModels
                .Include(s => s.Attributes) // Include attributes related to the subgroup
                .FirstOrDefaultAsync(s => s.Id == product.SubgroupId);

            if (subgroup == null)
            {
                return NotFound();
            }

            // Include attribute values related to each attribute
            foreach (var attribute in subgroup.Attributes)
            {
                _context.Entry(attribute)
                    .Collection(a => a.AttributeValues)
                    .Load();
            }

            // list of attribute values
            List<dynamic> productAttributeValues = new List<dynamic>();
            foreach (var attribute in product.AttributeValues)
            {
                productAttributeValues.Add(new { AttributeValueID = attribute.AttributeValueID, Value = attribute.Value }); // Adding both AttributeValueID and Value
            }

            ViewBag.ProductAttributeValues = productAttributeValues;
            ViewBag.ProductId = productId;
            ViewBag.ProductName = product.Name;

            return View(subgroup.Attributes.ToList()); // Convert HashSet to List
        }

        // GET: ProductAttributeValues/AddValue
        public IActionResult AddValue(int productId, int attributeId)
        {
            // Get product and attribute names
            var productName = _context.ProductModels.FirstOrDefault(p => p.Id == productId)?.Name;
            var attributeName = _context.Attributes.FirstOrDefault(a => a.AttributeID == attributeId)?.AttributeName;

            // Pass productId, attributeId, productName, and attributeName to the view
            ViewBag.ProductId = productId;
            ViewBag.AttributeId = attributeId;
            ViewBag.ProductName = productName;
            ViewBag.AttributeName = attributeName;

            return View();
        }

        // POST: ProductAttributeValues/AddValue
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddValue(int productId, int attributeId, string value)
        {
            if (ModelState.IsValid)
            {
                // Create new AttributeValues object
                var attributeValue = new AttributeValues
                {
                    ProductModelId = productId,
                    AttributeID = attributeId,
                    Value = value
                };

                // Add attributeValue to context and save changes
                _context.Add(attributeValue);
                await _context.SaveChangesAsync();

                // Redirect to the AddAttributeValues action with the productId parameter
                return RedirectToAction("AddAttributeValues", new { productId = productId });
            }
            
            return View();
        }




    }
}
