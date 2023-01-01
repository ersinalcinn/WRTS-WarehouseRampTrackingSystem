using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using wrts.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using Microsoft.CodeAnalysis;
using System.Globalization;
using Microsoft.AspNetCore.Authorization;

namespace wrts.Controllers
{
    [Authorize]
    public class ParkingLotController : Controller
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
        public IActionResult AddParkingLot()
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

            var parkinglot = dbContext.ParkingLot;
            return View(parkinglot);
        }
         public IActionResult ListParkingSpot(int id)
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

            List<SelectListItem> vehicles = new List<SelectListItem>();

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
        public IActionResult EditParkingLot(int id)
        {
            var parklot = dbContext.ParkingLot.FirstOrDefault(x => x.ParkingLotID == id);
            List<SelectListItem> degerler = (from i in dbContext.VehicleType.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.VehicleTypeName,
                                                 Value = i.VehicleTypeID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View(parklot);
        }
        public IActionResult EditParkingSpot(int id)
        {
            var parkspot = dbContext.ParkingSpot.FirstOrDefault(x => x.ParkingSpotID == id);

            List<SelectListItem> degerler = (from i in dbContext.Vehicles.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.driver_name + "  " + i.driver_surname + " " + i.citizenship_number,
                                                 Value = i.VehicleID.ToString()
                                             }).ToList();
            degerler.Add(new SelectListItem { Text = "NULL", Value = "0" });
            ViewBag.dgr = degerler;
            List<SelectListItem> degerler1 = (from i in dbContext.ParkingLot.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.ParkingLotName,
                                                  Value = i.ParkingLotID.ToString()
                                              }).ToList();
            ViewBag.dgr1 = degerler1;
            return View(parkspot);
        }

        public IActionResult DeleteParkingSpot(int id)
        {
            var p = dbContext.ParkingSpot.FirstOrDefault(x => x.ParkingSpotID == id);
            dbContext.ParkingSpot.Remove(p);
            dbContext.SaveChanges();
            TempData["message"] = "Silme işlemi başarıyla gerçekleştirildi...";
            return RedirectToAction("ListParkingLot", "ParkingLot");

        }
        public IActionResult ChangeParkingLot(ParkingLot p)
        {
            if (ModelState.IsValid)
            {
                dbContext.Update(p);
                dbContext.SaveChanges();
                TempData["message"] = "ParkingLot güncellendi...";
                return RedirectToAction("ListParkingLot", "ParkingLot");
            }
            else
            {
                TempData["message"] = "Lütfen geçerli bilgiler giriniz...";
                return RedirectToAction("ListParkingLot", "ParkingLot");
            }
        }
        public IActionResult ChangeParkingSpot(ParkingSpot p)
        {
            if (ModelState.IsValid)
            {
                var vehicle = dbContext.ParkingSpot.FirstOrDefault(x => x.VehicleID == p.VehicleID);
                if (p.ParkStatus == "NULL" && p.VehicleID == 0 || p.ParkStatus == "FULL" && p.VehicleID != 0)

                {


                    if (vehicle == null && vehicle.VehicleID == p.VehicleID)
                    {
                        dbContext.Update(p);
                        dbContext.SaveChanges();
                        TempData["message"] = "ParkingSpot güncellendi...";
                        return RedirectToAction("ListParkingLot", "ParkingLot");
                    }
                    else if (vehicle != null && vehicle.VehicleID == p.VehicleID)
                    {
                        dbContext.Update(p);
                        dbContext.SaveChanges();
                        TempData["message"] = "ParkingSpot güncellendi...";
                        return RedirectToAction("ListParkingLot", "ParkingLot");
                    }
                    else
                    {
                        TempData["message"] = "Seçilen araç başka bir park yerinde...";
                        return RedirectToAction("ListParkingLot", "ParkingLot");
                    }

                }
                else
                {
                    TempData["message"] = "Lütfen geçerli bilgiler giriniz...";
                    return RedirectToAction("ListParkingLot", "ParkingLot");
                }
            }
            else
            {
                TempData["message"] = "Lütfen boşaltmak istediğiniz park alanındaki aracı siliniz...";
                return RedirectToAction("ListParkingLot", "ParkingLot");
            }
        }
        public IActionResult CreateParkingSpot(ParkingSpot p)
        {


            if (ModelState.IsValid)
            {

                if (p.VehicleID != 0)
                {
                    var parkspot = dbContext.ParkingSpot.FirstOrDefault(x => x.VehicleID == p.VehicleID);
                    if (parkspot == null)
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
