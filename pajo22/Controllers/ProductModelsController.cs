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
            var pajo22Context = _context.ProductModels.Include(p => p.Subgroup);
            return View(await pajo22Context.ToListAsync());
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
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Image,Description,SubgroupId,color")] ProductModels productModels, IFormFile productImage)
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Image,Description,SubgroupId")] ProductModels productModels, IFormFile? productImage)
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
    }
}
