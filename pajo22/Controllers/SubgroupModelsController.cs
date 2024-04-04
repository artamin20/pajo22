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
    public class SubgroupModelsController : Controller
    {
        private readonly pajo22Context _context;

        public SubgroupModelsController(pajo22Context context)
        {
            _context = context;
        }

        // GET: SubgroupModels
        public async Task<IActionResult> Index()
        {
            var pajo22Context = _context.SubgroupModels.Include(s => s.GroupModels);
            return View(await pajo22Context.ToListAsync());
        }

        // GET: SubgroupModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subgroupModels = await _context.SubgroupModels
                .Include(s => s.GroupModels)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subgroupModels == null)
            {
                return NotFound();
            }

            return View(subgroupModels);
        }

        // GET: SubgroupModels/Create
        public IActionResult Create()
        {
            // Retrieve the list of groups from your database or wherever you store them
            List<SelectListItem> groups = _context.GroupModels
                .Select(g => new SelectListItem { Value = g.Id.ToString(), Text = g.Name })
                .ToList();

            // Add a default option if needed
            groups.Insert(0, new SelectListItem { Value = "", Text = "Select a group" });

            // Set ViewBag.GroupID
            ViewBag.GroupID = groups;

            return View();
        }
        // POST: SubgroupModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,GroupID")] SubgroupModels subgroupModels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subgroupModels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupID"] = new SelectList(_context.GroupModels, "Id", "Id", subgroupModels.GroupID);
            return View(subgroupModels);
        }

        // GET: SubgroupModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subgroupModels = await _context.SubgroupModels.FindAsync(id);
            if (subgroupModels == null)
            {
                return NotFound();
            }
            ViewData["GroupID"] = new SelectList(_context.GroupModels, "Id", "Name", subgroupModels.GroupID);
            return View(subgroupModels);
        }

        // POST: SubgroupModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,GroupID")] SubgroupModels subgroupModels)
        {
            if (id != subgroupModels.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subgroupModels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubgroupModelsExists(subgroupModels.Id))
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
            ViewData["GroupID"] = new SelectList(_context.GroupModels, "Id", "Id", subgroupModels.GroupID);
            return View(subgroupModels);
        }

        // GET: SubgroupModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subgroupModels = await _context.SubgroupModels
                .Include(s => s.GroupModels)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subgroupModels == null)
            {
                return NotFound();
            }

            return View(subgroupModels);
        }

        // POST: SubgroupModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subgroupModels = await _context.SubgroupModels.FindAsync(id);
            if (subgroupModels != null)
            {
                _context.SubgroupModels.Remove(subgroupModels);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubgroupModelsExists(int id)
        {
            return _context.SubgroupModels.Any(e => e.Id == id);
        }
    }
}
