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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] GroupModels groupModels)
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
            if (groupModels != null)
            {
                _context.GroupModels.Remove(groupModels);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupModelsExists(int id)
        {
            return _context.GroupModels.Any(e => e.Id == id);
        }
    }
}
