using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using wrts.Models;

namespace wrts.Controllers
{
    [Authorize]
    public class RampController : Controller
    {
        WRTSDbContext dbContext = new WRTSDbContext();
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
        public IActionResult AddRamp()
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


        public IActionResult ListRamp()
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

            var ramps = dbContext.Ramps;
            return View(ramps);
        }
        [HttpPost]
        public IActionResult CreateRamp(int num)
        {
            
            for (int i = 0; i < num; i++)
            {

                Ramp r = new Ramp();
                r.VehiclesID = 0;
                dbContext.Add(r);
                dbContext.SaveChanges();
            }

            return RedirectToAction("AddRamp","Ramp");
        }
        public IActionResult Delete(int id)
        {
            var ramp = dbContext.Ramps.FirstOrDefault(x => x.RampID == id);
            if (ramp != null)
            {
                dbContext.Remove(ramp);
                dbContext.SaveChanges();
                TempData["message1"] = "Rampa silindi";
                return RedirectToAction("ListRamp", "Ramp");
            }
            else
            {
                TempData["message1"] = "Rampa bilgisi bulunamadı";
                return RedirectToAction("ListRamp", "Ramp");
            }
        }
    }
}
