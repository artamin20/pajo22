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
            var subgroups = await _context.SubgroupModels
                .Include(s => s.GroupModels)
                .ToListAsync();

            // چک کردن گروه والد
            foreach (var subgroup in subgroups)
            {
                if (subgroup.ParentSubGroupId != null)
                {
                    var parentSubgroup = await _context.SubgroupModels.FindAsync(subgroup.ParentSubGroupId);
                    if (parentSubgroup.Status != SubgroupStatus.Active)
                    {
                        subgroup.Status = SubgroupStatus.Inactive;
                    }
                }
            }

            return View(subgroups);
        }
        // POST: SubgroupModels/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(List<SubgroupModels> subgroups)
        {
            if (ModelState.IsValid)
            {
                foreach (var subgroup in subgroups)
                {
                    //چک کردن گروه والد
                    if (subgroup.ParentSubGroupId != null)
                    {
                        var parentSubgroup = await _context.SubgroupModels.FindAsync(subgroup.ParentSubGroupId);

                        
                        if (parentSubgroup == null || parentSubgroup.Status != SubgroupStatus.Active)
                        {
                            subgroup.Status = SubgroupStatus.Inactive;
                        }
                        else
                        {
                            subgroup.Status = SubgroupStatus.Active;
                        }
                    }
                }

                _context.UpdateRange(subgroups);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            
            return View(subgroups);
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
            groups.Insert(0, new SelectListItem { Value = "", Text = "انتخاب گروه اصلی" });

            // گرفتن زیر گروه ها
            List<SelectListItem> parentSubgroups = _context.SubgroupModels
                .Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name })
                .ToList();

            // default
            parentSubgroups.Insert(0, new SelectListItem { Value = "", Text = "انتخاب گروه والد" });

            
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
                    ModelState.AddModelError("ParentSubGroupId", "گروه والد و زیر گروه آن باید به هم مرتبط باشند");
                    // زیرگروه ها
                    PopulateDropdownLists(subgroupModels.GroupID, subgroupModels.ParentSubGroupId);
                    return View(subgroupModels);
                }
            }
            if (ModelState.IsValid)
            {
                _context.Add(subgroupModels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Populate the dropdown lists
            PopulateDropdownLists(subgroupModels.GroupID, subgroupModels.ParentSubGroupId);
            return View(subgroupModels);
        }

        // لیست زیر گروه ها 
        private void PopulateDropdownLists(int? groupID, int? parentSubGroupId)
        {
            ViewData["GroupID"] = new SelectList(_context.GroupModels, "Id", "Name", groupID);
            ViewData["ParentSubGroupId"] = new SelectList(_context.SubgroupModels.Where(s => s.GroupID == groupID), "Id", "Name", parentSubGroupId);

            List<SelectListItem> groups = _context.GroupModels
                .Select(g => new SelectListItem { Value = g.Id.ToString(), Text = g.Name })
                .ToList();
            groups.Insert(0, new SelectListItem { Value = "", Text = "انتخاب گروه اصلی" });
            ViewBag.Groups = groups;

            List<SelectListItem> parentSubgroups = _context.SubgroupModels
                .Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name })
                .ToList();

            parentSubgroups.Insert(0, new SelectListItem { Value = "", Text = "انتخاب گروه والد" });
            ViewBag.ParentSubgroups = parentSubgroups;
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

            // گرفتن گروه پایه
            List<SelectListItem> groups = _context.GroupModels
                .Select(g => new SelectListItem { Value = g.Id.ToString(), Text = g.Name })
                .ToList();
            groups.Insert(0, new SelectListItem { Value = "", Text = "انتخاب گروه اصلی" });
            ViewBag.Groups = groups;

            // گرفنن زیر گروه 
            List<SelectListItem> parentSubgroups = _context.SubgroupModels
                .Where(s => s.GroupID == subgroupModels.GroupID)
                .Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name })
                .ToList();
            parentSubgroups.Insert(0, new SelectListItem { Value = "", Text = "انتخاب گروه والد" });
            ViewBag.ParentSubgroups = parentSubgroups;

            return View(subgroupModels);
        }

        // POST: SubgroupModels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,GroupID,ParentSubGroupId,Status")] SubgroupModels subgroupModels)
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

                    // بروز رسانی وضعیت زیرگروه ها در صورت غیر فعال شدن
                    if (subgroupModels.Status == SubgroupStatus.Inactive)
                    {
                        await UpdateChildSubgroupsStatus(subgroupModels.Id, SubgroupStatus.Inactive);
                    }
                    else if (subgroupModels.Status == SubgroupStatus.Active)
                    {
                        await UpdateChildSubgroupsStatus(subgroupModels.Id, SubgroupStatus.Active);
                    }

                    return RedirectToAction(nameof(Index));
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
            }


            return View(subgroupModels);
        }

        // به روز رسانی وضعیت شاخه های زیرگروه های گروه والد به صورت بازگشتی
        private async Task UpdateChildSubgroupsStatus(int parentId, SubgroupStatus status)
        {
            // گرفتن فرزند های گروه والد
            var childSubgroups = await _context.SubgroupModels
                .Where(s => s.ParentSubGroupId == parentId)
                .ToListAsync();

            foreach (var childSubgroup in childSubgroups)
            {
                // به روز رسانی وضعیت زیرگروه فرزند
                childSubgroup.Status = status;
                _context.Update(childSubgroup);

                // به روز رسانی فرزندان فرزند والد به صورت بازگشتی
                await UpdateChildSubgroupsStatus(childSubgroup.Id, status);
            }


            await _context.SaveChangesAsync();
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
