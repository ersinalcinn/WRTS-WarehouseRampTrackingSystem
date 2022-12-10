using Microsoft.AspNetCore.Mvc;

namespace wrts.Controllers
{
    public class RampController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
