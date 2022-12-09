using Microsoft.AspNetCore.Mvc;

namespace wrts.Controllers
{
    public class LoginController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
