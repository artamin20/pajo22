using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pajo22.Data;
using pajo22.Models;
using System.Linq;
using System.Threading.Tasks;

namespace pajo22.Controllers
{
    public class SubgroupAttributeController : Controller
    {
        private readonly pajo22Context _context;

        public SubgroupAttributeController(pajo22Context context)
        {
            _context = context;
        }

        // GET: SubgroupAttribute
        public async Task<IActionResult> Index(int? subgroupId)
        {
            if (subgroupId == null)
            {
                return NotFound();
            }

            var subgroup = await _context.SubgroupModels
                .Include(s => s.Attributes)
                .FirstOrDefaultAsync(s => s.Id == subgroupId);

            if (subgroup == null)
            {
                return NotFound();
            }

            return View(subgroup);
        }

        // GET: SubgroupAttribute/Create
        public IActionResult Create(int? subgroupId)
        {
            if (subgroupId == null)
            {
                return NotFound();
            }

            ViewData["SubgroupId"] = subgroupId;
            return View();
        }

        // POST: SubgroupAttribute/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AttributeID,AttributeName,SubgroupId")] Attributes attribute)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attribute);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { subgroupId = attribute.SubgroupId });
            }
            return View(attribute);
        }

        // GET: SubgroupAttribute/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attribute = await _context.Attributes
                .FirstOrDefaultAsync(m => m.AttributeID == id);
            if (attribute == null)
            {
                return NotFound();
            }

            return View(attribute);
        }

        // POST: SubgroupAttribute/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var attribute = await _context.Attributes.FindAsync(id);
            if (attribute == null)
            {
                return NotFound();
            }

            // Recursively delete all attribute values under the attribute
            var attributeValuesToDelete = _context.AttributeValues.Where(av => av.AttributeID == id).ToList();
            foreach (var attributeValue in attributeValuesToDelete)
            {
                _context.AttributeValues.Remove(attributeValue);
            }

            _context.Attributes.Remove(attribute);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "SubgroupAttribute", new { subgroupId = attribute.SubgroupId });
        }

    }
}
