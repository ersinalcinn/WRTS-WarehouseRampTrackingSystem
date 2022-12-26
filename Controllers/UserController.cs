using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using wrts.Models;
using System.Linq;

namespace wrts.Controllers
{
    public class UserController : Controller
    {
        WRTSDbContext dbContext = new WRTSDbContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddUser()
        {
              List<SelectListItem> degerler = (from i in dbContext.Department.ToList()
                                             select new SelectListItem
                                             {
                                                 Text=i.DepartmentName,
                                                 Value=i.DepartmentID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
            
        }
        public IActionResult Create(User u)
        {
            if (ModelState.IsValid)
            {
                var user = dbContext.User.FirstOrDefault(x => x.Email == u.Email);
                if (user == null)
                {

                    dbContext.Add(u);
                    dbContext.SaveChanges();
                    TempData["message"] = "Kayıt eklendi";
                    return RedirectToAction("AddUser", "User");
                }
                else
                {
                    TempData["message"] = "Bu maile ait bir kullanıcı sistemde kayıtlı ";
                    return RedirectToAction("AddUser", "User");
                }
            }
            else
            {
                return RedirectToAction("AddUser", "User");
            }
        }

        public IActionResult ListUser()
        {
            var user = dbContext.User;
            
            return View(user);
        }
    }
}
