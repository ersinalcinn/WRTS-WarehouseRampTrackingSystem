using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using wrts.Models;
using System.Linq;
using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using wrts.Migrations;

namespace wrts.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        WRTSDbContext dbContext = new WRTSDbContext();
        [HttpPost]
        public IActionResult Index()
        {
            var defaultCultures = new List<CultureInfo>()
            {
                new CultureInfo("tr-TR"),
                new CultureInfo("en-US"),
            };

            CultureInfo[] cinfo = CultureInfo.GetCultures(CultureTypes.AllCultures);
            var cultureItems = cinfo.Where(x => defaultCultures.Contains(x))
                .Select(c => new SelectListItem { Value = c.Name, Text = c.DisplayName })
                .ToList();
            ViewData["Cultures"] = cultureItems;

            return View();
        }
        public IActionResult AddUser()
        {
            var defaultCultures = new List<CultureInfo>()
            {
                new CultureInfo("tr-TR"),
                new CultureInfo("en-US"),
            };

            CultureInfo[] cinfo = CultureInfo.GetCultures(CultureTypes.AllCultures);
            var cultureItems = cinfo.Where(x => defaultCultures.Contains(x))
                .Select(c => new SelectListItem { Value = c.Name, Text = c.DisplayName })
                .ToList();
            ViewData["Cultures"] = cultureItems;
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
        public IActionResult Update(User u)
        {
            if (ModelState.IsValid)
            {
                var user = dbContext.User.FirstOrDefault(x => x.Email == u.Email);
                dbContext.Remove(user);
                dbContext.Add(u);
                dbContext.SaveChanges();
                TempData["message2"] = "Kullanıcı Güncellendi";
                return  RedirectToAction("Index","CallUserApi");
            }
            else
            {
                TempData["message2"] = "Kullanıcı bulunamadı";
                return  RedirectToAction("Index", "CallUserApi");
            }
        }

        public IActionResult ListUser()
        {
            var defaultCultures = new List<CultureInfo>()
            {
                new CultureInfo("tr-TR"),
                new CultureInfo("en-US"),
            };

            CultureInfo[] cinfo = CultureInfo.GetCultures(CultureTypes.AllCultures);
            var cultureItems = cinfo.Where(x => defaultCultures.Contains(x))
                .Select(c => new SelectListItem { Value = c.Name, Text = c.DisplayName })
                .ToList();
            ViewData["Cultures"] = cultureItems;

            var user = dbContext.User;
            
            return View(user);
        }

        public IActionResult Edit(int id)
        {
            List<SelectListItem> degerler = (from i in dbContext.Department.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.DepartmentName,
                                                 Value = i.DepartmentID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            var user = dbContext.User.FirstOrDefault(x => x.UserID == id);
            return View(user);
        }
        public IActionResult Delete(int id)
        {
            var user = dbContext.User.FirstOrDefault(x => x.UserID == id);
            if (user != null)
            {
                dbContext.Remove(user);
                dbContext.SaveChanges();
                TempData["message1"] = "Kayıt silindi";
                return RedirectToAction("Index", "CallUserApi");
            }
            else
            {
                TempData["message1"] = "Kullanıcı bulunamadı";
                return RedirectToAction("Index", "CallUserApi");
            }
        }
    }
}
