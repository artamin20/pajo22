using Microsoft.AspNetCore.Mvc;

namespace pajo22.Controllers
{
    public class home : Controller
    {
        public IActionResult Index()
        {
            //check user controller for the actual home page!
            return View();
        }
    }
}
