﻿using System;
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
    public class AttributesController : Controller
    {
        private readonly pajo22Context _context;

        public AttributesController(pajo22Context context)
        {
            _context = context;
        }

        // GET: Attributes
        public async Task<IActionResult> Index()
        {
            var pajo22Context = _context.Attributes.Include(a => a.Subgroup);
            return View(await pajo22Context.ToListAsync());
        }

        // GET: Attributes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attributes = await _context.Attributes
                .Include(a => a.Subgroup)
                .FirstOrDefaultAsync(m => m.AttributeID == id);
            if (attributes == null)
            {
                return NotFound();
            }

            return View(attributes);
        }

        // GET: Attributes/Create
        public IActionResult Create(int? subgroupId)
        {
            ViewData["SubgroupId"] = new SelectList(_context.SubgroupModels, "Id", "Name", subgroupId);
            return View();
        }


        // POST: Attributes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AttributeID,AttributeName,SubgroupId")] Attributes attributes)
        {
            // Remove ModelState validation check
            // if (ModelState.IsValid)
            // {
            _context.Add(attributes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            // }
            // ViewData["SubgroupId"] = new SelectList(_context.SubgroupModels, "Id", "Name", attributes.SubgroupId);
            // return View(attributes);
        }


        // GET: Attributes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attributes = await _context.Attributes.FindAsync(id);
            if (attributes == null)
            {
                return NotFound();
            }
            ViewData["SubgroupId"] = new SelectList(_context.SubgroupModels, "Id", "Id", attributes.SubgroupId);
            return View(attributes);
        }

        // POST: Attributes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AttributeID,AttributeName,SubgroupId")] Attributes attributes)
        {
            if (id != attributes.AttributeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attributes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttributesExists(attributes.AttributeID))
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
            ViewData["SubgroupId"] = new SelectList(_context.SubgroupModels, "Id", "Id", attributes.SubgroupId);
            return View(attributes);
        }

        // GET: Attributes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attributes = await _context.Attributes
                .Include(a => a.Subgroup)
                .FirstOrDefaultAsync(m => m.AttributeID == id);
            if (attributes == null)
            {
                return NotFound();
            }

            return View(attributes);
        }

        // POST: Attributes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attributes = await _context.Attributes.FindAsync(id);
            if (attributes != null)
            {
                _context.Attributes.Remove(attributes);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttributesExists(int id)
        {
            return _context.Attributes.Any(e => e.AttributeID == id);
        }
    }
}
