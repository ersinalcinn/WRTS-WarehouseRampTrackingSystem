using Microsoft.AspNetCore.Mvc;
using System.Linq;
using wrts.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using wrts.Migrations;

namespace wrts.Controllers
{
    public class LoginController : Controller
    {
        WRTSDbContext db=new WRTSDbContext();

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]

        public async Task<IActionResult> Check(User loginRequest)
        {
           
            var userdetails = db.User.FirstOrDefault(x => x.Email == loginRequest.Email && x.Password == loginRequest.Password);
            var userdepartment = loginRequest.DepartmentID.ToString();
            if (userdetails != null)
            {
                var claims = new List<Claim>();
                claims.Add (new Claim(ClaimTypes.Name, userdetails.Name));
                TempData["Name"] = userdetails.Name;
                TempData["SName"] = userdetails.Surname;

                var x = db.Department.Find(userdetails.DepartmentID);
                TempData["Department"] = x.DepartmentName;

                var useridentity = new ClaimsIdentity(claims,"Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index","Home");
            }
            else
            {
                TempData["message"] = "Email or password wrong";
                return RedirectToAction("Index", "Login");
                
            }
                 
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Login");
        }
    }
}
