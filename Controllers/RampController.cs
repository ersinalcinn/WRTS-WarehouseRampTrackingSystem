using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using wrts.Models;
using Microsoft.AspNetCore.Mvc;

namespace wrts.Controllers
{
    
    public class RampController : Controller
    {
        WRTSDbContext dbContext = new WRTSDbContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddRamp()
        {
            return View();
        }


        public IActionResult ListRamp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateRamp(int num)
        {
            for (int i = 0; i < 5; i++)
            {
                dbContext.Add(null);
                dbContext.SaveChanges();
            }

            return RedirectToAction("AddRamp","Ramp");
        }
    }
}
