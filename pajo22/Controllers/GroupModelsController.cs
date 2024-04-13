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
    public class GroupModelsController : Controller
    {
        private readonly pajo22Context _context;

        public GroupModelsController(pajo22Context context)
        {
            _context = context;
        }

        // GET: GroupModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.GroupModels.ToListAsync());
        }

        // GET: GroupModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupModels = await _context.GroupModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupModels == null)
            {
                return NotFound();
            }

            return View(groupModels);
        }

        // GET: GroupModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GroupModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] GroupModels groupModels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupModels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(groupModels);
        }

        // GET: GroupModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupModels = await _context.GroupModels.FindAsync(id);
            if (groupModels == null)
            {
                return NotFound();
            }
            return View(groupModels);
        }

        // POST: GroupModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Status")] GroupModels groupModels)
        {
            if (id != groupModels.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupModels);
                    await _context.SaveChangesAsync();

                    // Get all subgroups associated with this group
                    var subgroups = await _context.SubgroupModels
                        .Where(s => s.GroupID == id)
                        .Include(s => s.Product)
                        .ToListAsync();

                    // Update status of subgroups and products based on group status
                    if (groupModels.Status == GroupStatus.Active)
                    {
                        // Set subgroups and products to Active
                        foreach (var subgroup in subgroups)
                        {
                            subgroup.Status = SubgroupStatus.Active;
                            _context.Update(subgroup);

                            foreach (var product in subgroup.Product)
                            {
                                product.Status = ProductStatus.Active;
                                _context.Update(product);
                            }
                        }
                    }
                    else if (groupModels.Status == GroupStatus.Inactive)
                    {
                        // Set subgroups and products to Inactive
                        foreach (var subgroup in subgroups)
                        {
                            subgroup.Status = SubgroupStatus.Inactive;
                            _context.Update(subgroup);

                            foreach (var product in subgroup.Product)
                            {
                                product.Status = ProductStatus.Inactive;
                                _context.Update(product);
                            }
                        }
                    }

                    // Save changes to the database
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupModelsExists(groupModels.Id))
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
            return View(groupModels);
        }


        // GET: GroupModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupModels = await _context.GroupModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupModels == null)
            {
                return NotFound();
            }

            return View(groupModels);
        }

        // POST: GroupModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groupModels = await _context.GroupModels.FindAsync(id);
            if (groupModels == null)
            {
                return NotFound();
            }

            // Get all subgroups associated with this group
            var subgroups = await _context.SubgroupModels
                .Where(s => s.GroupID == id)
                .ToListAsync();

            foreach (var subgroup in subgroups)
            {
                // Delete all products associated with this subgroup
                var products = await _context.ProductModels
                    .Where(p => p.SubgroupId == subgroup.Id)
                    .ToListAsync();

                _context.ProductModels.RemoveRange(products);

                // Delete the subgroup
                _context.SubgroupModels.Remove(subgroup);
            }

            // Delete the group
            _context.GroupModels.Remove(groupModels);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool GroupModelsExists(int id)
        {
            return _context.GroupModels.Any(e => e.Id == id);
        }
    }
}
