using Microsoft.AspNetCore.Mvc;
using pajo22.Data;
using pajo22.Models; // Assuming your ProductModels class is in this namespace

namespace pajo22.Controllers
{
    public class userController : Controller
    {
        private readonly pajo22Context _context;

        public userController(pajo22Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // گرفتن لیست محصولات 
            var products = _context.ProductModels.ToList();

            // در این قسمت صفحه ی اصلی وجود دارد 
            return View(products);
        }
    }
}
