using Microsoft.AspNetCore.Mvc;
using wrts.Models;

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
            var ramps = dbContext.Ramps;
            return View(ramps);
        }
        [HttpPost]
        public IActionResult CreateRamp(int num)
        {
            
            for (int i = 0; i < 5; i++)
            {

                Ramp r = new Ramp();
                r.VehiclesID = 0;
                dbContext.Add(r);
                dbContext.SaveChanges();
            }

            return RedirectToAction("AddRamp","Ramp");
        }
    }
}
