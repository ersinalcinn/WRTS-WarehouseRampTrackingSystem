using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using wrts.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using Microsoft.CodeAnalysis;

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

            var parkingspot = dbContext.ParkingSpot.Where(x => x.ParkingLotID == id);
           
            List<ParkingSpot> objList = (from i in dbContext.ParkingSpot.ToList()
                                         where i.ParkingSpotID == id select i).ToList();
            return View(parkingspot);
            
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
                return RedirectToAction("AddParkingLot", "ParkingLot");
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
        public IActionResult AddParkingSpot(int id)
        {
            List<SelectListItem> vehicles= new List<SelectListItem>();
            
            vehicles = (from i in dbContext.Vehicles.ToList()
                                             select new SelectListItem
                                             {

                                                 Text = i.citizenship_number,
                                                 Value = i.VehicleID.ToString()
                                             }).ToList();

            vehicles.Add(new SelectListItem { Text = "NULL", Value = "0" });
            ViewBag.vehicle = vehicles;

            List<SelectListItem> parkinglot = (from i in dbContext.ParkingLot.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.ParkingLotName,
                                                 Value = i.ParkingLotID.ToString()
                                             }).ToList();
            ViewBag.parkinglot = parkinglot;
     
            return View();
        }
        public IActionResult CreateParkingSpot(ParkingSpot p)
        {
            
           
            if (ModelState.IsValid) {
                
             if(p.VehicleID!=0)
             {
                    var parkspot = dbContext.ParkingSpot.FirstOrDefault(x => x.VehicleID == p.VehicleID);
                    if(parkspot==null)
                    {
                        dbContext.Add(p);
                        dbContext.SaveChanges();
                        TempData["message"] = "Parking Spot eklendi";
                        return RedirectToAction("ListParkingLot", "ParkingLot");
                    }
                    else
                    {
                        
                        TempData["message"] = "Seçilen araç mevcut...";
                        return RedirectToAction("ListParkingLot", "ParkingLot");
                    }
                    
             }
            else
            {
                    dbContext.Add(p);
                    dbContext.SaveChanges();
                    TempData["message"] = "Parking Spot eklendi";
                    return RedirectToAction("ListParkingLot", "ParkingLot");

             }
        }
            else
            {
                TempData["message"] = "Uygun veri giriniz...";
                return RedirectToAction("ListParkingLot", "ParkingLot");
            }
        }
    }
}
