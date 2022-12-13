using Microsoft.AspNetCore.Mvc;
using System.Linq;
using wrts.Models;

namespace wrts.Controllers
{
    public class LoginController : Controller
    {
        WRTSDbContext db=new WRTSDbContext();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CheckLogin(User u)
        {
            var userdetails = db.User.FirstOrDefault(x=>x.Email == u.Email && x.Password == u.Password);
            if (userdetails != null)
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                TempData["message"] = "User or password  wrong";
                return RedirectToAction("Index", "Login");

            }
            
        }
    }
}
