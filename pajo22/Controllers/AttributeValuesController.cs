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
//while this page should technicly exist I made it unreachable via normal methods in the site bc it only will make the user confused and the layout is generated by 
//visual studio and it doesnt match the sites style 
//


























//this code isnt relative to the user expirence 
{
    public class AttributeValuesController : Controller
    {
        private readonly pajo22Context _context;

        public AttributeValuesController(pajo22Context context)
        {
            _context = context;
        }

        // GET: AttributeValues
        public async Task<IActionResult> Index()
        {
            var pajo22Context = _context.AttributeValues.Include(a => a.Attribute).Include(a => a.ProductModel);
            return View(await pajo22Context.ToListAsync());
        }

        // GET: AttributeValues/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attributeValues = await _context.AttributeValues
                .Include(a => a.Attribute)
                .Include(a => a.ProductModel)
                .FirstOrDefaultAsync(m => m.AttributeValueID == id);
            if (attributeValues == null)
            {
                return NotFound();
            }

            return View(attributeValues);
        }

        // GET: AttributeValues/Create
        public IActionResult Create()
        {
            ViewData["AttributeID"] = new SelectList(_context.Attributes, "AttributeID", "AttributeName");
            ViewData["ProductModelId"] = new SelectList(_context.ProductModels, "Id", "Name");
            return View();
        }

        // POST: AttributeValues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AttributeValueID,AttributeID,ProductModelId,Value")] AttributeValues attributeValues)
        {
            // if (ModelState.IsValid)
            // {
            _context.Add(attributeValues);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            // }
            // ViewData["AttributeID"] = new SelectList(_context.Attributes, "AttributeID", "AttributeName", attributeValues.AttributeID);
            // ViewData["ProductModelId"] = new SelectList(_context.ProductModels, "Id", "Name", attributeValues.ProductModelId);
            // return View(attributeValues);
        }


        // GET: AttributeValues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attributeValues = await _context.AttributeValues.FindAsync(id);
            if (attributeValues == null)
            {
                return NotFound();
            }
            ViewData["AttributeID"] = new SelectList(_context.Attributes, "AttributeID", "AttributeName", attributeValues.AttributeID);
            ViewData["ProductModelId"] = new SelectList(_context.ProductModels, "Id", "Description", attributeValues.ProductModelId);
            return View(attributeValues);
        }

        // POST: AttributeValues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AttributeValueID,AttributeID,ProductModelId,Value")] AttributeValues attributeValues)
        {
            if (id != attributeValues.AttributeValueID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attributeValues);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttributeValuesExists(attributeValues.AttributeValueID))
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
            ViewData["AttributeID"] = new SelectList(_context.Attributes, "AttributeID", "AttributeName", attributeValues.AttributeID);
            ViewData["ProductModelId"] = new SelectList(_context.ProductModels, "Id", "Description", attributeValues.ProductModelId);
            return View(attributeValues);
        }

        // GET: AttributeValues/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attributeValues = await _context.AttributeValues
                .Include(a => a.Attribute)
                .Include(a => a.ProductModel)
                .FirstOrDefaultAsync(m => m.AttributeValueID == id);
            if (attributeValues == null)
            {
                return NotFound();
            }

            return View(attributeValues);
        }

        // POST: AttributeValues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attributeValues = await _context.AttributeValues.FindAsync(id);
            if (attributeValues != null)
            {
                _context.AttributeValues.Remove(attributeValues);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AttributeValuesExists(int id)
        {
            return _context.AttributeValues.Any(e => e.AttributeValueID == id);
        }
    }
}
