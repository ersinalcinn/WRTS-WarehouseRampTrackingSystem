using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using wrts.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace wrts.Controllers
{
    public class ParkingLotController : Controller
    {
        WRTSDbContext dbContext = new WRTSDbContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddParkingLot()
        {
            List<SelectListItem> degerler = (from i in dbContext.VehicleType.ToList()
                                             select new SelectListItem
                                             {
                                                 Text=i.VehicleTypeName,
                                                 Value=i.VehicleTypeID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        public IActionResult CreateParkingLot(ParkingLot p)
        {

            if (ModelState.IsValid)
            {
                var parkinglot = dbContext.ParkingLot.FirstOrDefault(x => x.ParkingLotName == p.ParkingLotName);
                if (parkinglot == null)
                {

                    dbContext.Add(p);
                    dbContext.SaveChanges();
                    TempData["message"] = "Parking Lot eklendi";
                    return RedirectToAction("AddParkingLot", "ParkingLot");
                }
                else
                {
                    TempData["message"] = "Bu isimde bir park alanı mevcuttur. ";
                    return RedirectToAction("AddParkingLot", "ParkingLot");
                }
            }
            else
            {
                return RedirectToAction("AddUser", "User");
            }
        }
    }
}
