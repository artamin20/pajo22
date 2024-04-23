using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pajo22.Data;
using pajo22.Models;
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

        // Other actions for editing and deleting attributes can be added here
    }


}

