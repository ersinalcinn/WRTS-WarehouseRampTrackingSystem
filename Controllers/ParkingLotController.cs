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
        public IActionResult ListParkingLot()
        {
            var parkinglot = dbContext.ParkingLot;
            return View(parkinglot);
        }
         public IActionResult ListParkingSpot(int id)
        {

            // var parkingspot = dbContext.ParkingSpot.Select(;
           
            List<ParkingSpot> objList = (from i in dbContext.ParkingSpot.ToList()
                                         where i.ParkingSpotID == id select i).ToList();
            return View(objList);
            
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
        public IActionResult DeleteParkingLot(int id)
        {
            var parkinglot = dbContext.ParkingLot.FirstOrDefault(x => x.ParkingLotID == id);
            var checkParkingSpot = dbContext.ParkingSpot.FirstOrDefault(x => x.ParkingLotID == id);
            if (checkParkingSpot!=null)
            {
                
                TempData["message"] = "Kayıt silinemedi lütfen ilk önce park yerlerini siliniz..";
                return RedirectToAction("ListParkingLot", "ParkingLot");
            }
            else
            {
                dbContext.Remove(parkinglot);
                dbContext.SaveChanges();
                TempData["message"] = "İstenilen kayıt başarıyla silindi.";
                return RedirectToAction("ListParkingLot", "ParkingLot");
            }
                    

            
        }
    }
}
