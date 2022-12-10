using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using wrts.Models;

namespace wrts.Controllers
{
    public class VehicleController : Controller
    {
        WRTSDbContext k = new WRTSDbContext();
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult VehicleList()
        {
            var vehicles = k.Vehicles;
            return View(vehicles);
        }
    }
}
