using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using wrts.Models;

namespace wrts.Controllers
{
    [Authorize]
    public class VehicleController : Controller
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
        
        public IActionResult VehicleList()
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
            var vehicles = dbContext.Vehicles;
            return View(vehicles);
        }
        public IActionResult ListVehicleType()
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
            var vt = dbContext.VehicleType;
            return View(vt);
        }
        public IActionResult AddVehicle()
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
        public IActionResult AddVehicleType()
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
        public IActionResult Create(VehicleType u)
        {
            if (ModelState.IsValid)
            {
                var user = dbContext.VehicleType.FirstOrDefault(x => x.VehicleTypeName == u.VehicleTypeName);
                if (user == null)
                {

                    dbContext.Add(u);
                    dbContext.SaveChanges();
                    TempData["messagevt"] = "Araç Türü eklendi";
                    return RedirectToAction("AddVehicleType", "Vehicle");
                }
                else
                {
                    TempData["messagevt"] = "Bu Araç Türü Mevcut";
                    return RedirectToAction("AddVehicleType", "Vehicle");
                }
            }
            else
            {
                return RedirectToAction("AddVehicleType", "Vehicle");
            }
        }
        public IActionResult CreateVehicle(Vehicles u)
        {
            if (ModelState.IsValid)
            {
                var user = dbContext.Vehicles.FirstOrDefault(x => x.VehicleID == u.VehicleID);
                if (user == null)
                {

                    dbContext.Add(u);
                    dbContext.SaveChanges();
                    TempData["messagevtt"] = "Araç eklendi";
                    return RedirectToAction("AddVehicle", "Vehicle");
                }
                else
                {
                    TempData["messagevtt"] = "Bu Araç Mevcut";
                    return RedirectToAction("AddVehicle", "Vehicle");
                }
            }
            else
            {
                return RedirectToAction("AddVehicle", "Vehicle");
            }
        }
        public IActionResult DeleteType(int id)
        {
            var vehicle = dbContext.VehicleType.FirstOrDefault(x => x.VehicleTypeID == id);
            if (vehicle != null)
            {
                dbContext.Remove(vehicle);
                dbContext.SaveChanges();
                TempData["message4"] = "Araç türü silindi";
                return RedirectToAction("ListVehicleType", "Vehicle");
            }
            else
            {
                TempData["message4"] = "Araç tür bilgisi bulunamadı";
                return RedirectToAction("ListVehicleType", "Vehicle");
            }
        }
        public IActionResult DeleteVehicle(int id)
        {
            var vehicle = dbContext.Vehicles.FirstOrDefault(x => x.VehicleID == id);
            if (vehicle != null)
            {
                dbContext.Remove(vehicle);
                dbContext.SaveChanges();
                TempData["message4"] = "Araç silindi";
                return RedirectToAction("VehicleList", "Vehicle");
            }
            else
            {
                TempData["message4"] = "Araç bilgisi bulunamadı";
                return RedirectToAction("VehicleList", "Vehicle");
            }
        }

    }
}
