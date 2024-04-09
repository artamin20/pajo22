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
            // گرفتن گروه پایه
            List<SelectListItem> groups = _context.GroupModels
                .Select(g => new SelectListItem { Value = g.Id.ToString(), Text = g.Name })
                .ToList();

            // default
            groups.Insert(0, new SelectListItem { Value = "", Text = "Select a group" });

            // گرفتن زیر گروه ها
            List<SelectListItem> parentSubgroups = _context.SubgroupModels
                .Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name })
                .ToList();

            // default
            parentSubgroups.Insert(0, new SelectListItem { Value = "", Text = "Select a parent subgroup" });

            
            ViewBag.Groups = groups;
            ViewBag.ParentSubgroups = parentSubgroups;

            return View();
        }

        // POST: SubgroupModels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,GroupID,ParentSubGroupId")] SubgroupModels subgroupModels)
        {
            // روابط گروه و زیر گروه به هم یکی باشن
            if (subgroupModels.ParentSubGroupId != null)
            {
                var parentSubgroup = await _context.SubgroupModels.FindAsync(subgroupModels.ParentSubGroupId);
                if (parentSubgroup.GroupID != subgroupModels.GroupID)
                {
                    ModelState.AddModelError("ParentSubGroupId", "The selected parent subgroup must belong to the same group.");
                    // لیست گروه ها
                    ViewData["GroupID"] = new SelectList(_context.GroupModels, "Id", "Name", subgroupModels.GroupID);
                    ViewData["ParentSubGroupId"] = new SelectList(_context.SubgroupModels.Where(s => s.GroupID == subgroupModels.GroupID), "Id", "Name", subgroupModels.ParentSubGroupId);
                    return View(subgroupModels);
                }
            }
            if (ModelState.IsValid)
            {
                _context.Add(subgroupModels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            
            ViewData["GroupID"] = new SelectList(_context.GroupModels, "Id", "Name", subgroupModels.GroupID);
            ViewData["ParentSubGroupId"] = new SelectList(_context.SubgroupModels.Where(s => s.GroupID == subgroupModels.GroupID), "Id", "Name", subgroupModels.ParentSubGroupId);

            
            List<SelectListItem> groups = _context.GroupModels
                .Select(g => new SelectListItem { Value = g.Id.ToString(), Text = g.Name })
                .ToList();
            groups.Insert(0, new SelectListItem { Value = "", Text = "Select a group" });
            ViewBag.Groups = groups;

            
            List<SelectListItem> parentSubgroups = _context.SubgroupModels
                .Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name })
                .ToList();

            
            parentSubgroups.Insert(0, new SelectListItem { Value = "", Text = "Select a parent subgroup" });
            ViewBag.ParentSubgroups = parentSubgroups;

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

            // Retrieve the list of groups for the ViewBag
            List<SelectListItem> groups = _context.GroupModels
                .Select(g => new SelectListItem { Value = g.Id.ToString(), Text = g.Name })
                .ToList();
            groups.Insert(0, new SelectListItem { Value = "", Text = "Select a group" });
            ViewBag.Groups = groups;

            // Retrieve the list of subgroups 
            List<SelectListItem> parentSubgroups = _context.SubgroupModels
                .Where(s => s.GroupID == subgroupModels.GroupID)
                .Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name })
                .ToList();
            parentSubgroups.Insert(0, new SelectListItem { Value = "", Text = "Select a parent subgroup" });
            ViewBag.ParentSubgroups = parentSubgroups;

            return View(subgroupModels);
        }

        // POST: SubgroupModels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,GroupID,ParentSubGroupId")] SubgroupModels subgroupModels)
        {
            if (id != subgroupModels.Id)
            {
                return NotFound();
            }

            //چک کردن مساوی بودن گروه بالا
            if (subgroupModels.ParentSubGroupId != null)
            {
                var parentSubgroup = await _context.SubgroupModels.FindAsync(subgroupModels.ParentSubGroupId);
                if (parentSubgroup.GroupID != subgroupModels.GroupID)
                {
                    ModelState.AddModelError("ParentSubGroupId", "The selected parent subgroup must belong to the same group.");
                    
                    ViewData["GroupID"] = new SelectList(_context.GroupModels, "Id", "Name", subgroupModels.GroupID);
                    ViewData["ParentSubGroupId"] = new SelectList(_context.SubgroupModels.Where(s => s.GroupID == subgroupModels.GroupID), "Id", "Name", subgroupModels.ParentSubGroupId);
                    return View(subgroupModels);
                }
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

            
            ViewData["GroupID"] = new SelectList(_context.GroupModels, "Id", "Name", subgroupModels.GroupID);
            ViewData["ParentSubGroupId"] = new SelectList(_context.SubgroupModels.Where(s => s.GroupID == subgroupModels.GroupID), "Id", "Name", subgroupModels.ParentSubGroupId);
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
