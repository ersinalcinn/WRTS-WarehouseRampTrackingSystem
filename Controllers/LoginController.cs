using Microsoft.AspNetCore.Mvc;
using System.Linq;
using wrts.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using wrts.Migrations;
using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Principal;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;

namespace wrts.Controllers
{
    public class LoginController : Controller
    {
        WRTSDbContext db = new WRTSDbContext();

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
        [HttpPost]

        public async Task<IActionResult> Check(User loginRequest)
        {
           
            var userdetails = db.User.FirstOrDefault(x => x.Email == loginRequest.Email && x.Password == loginRequest.Password);
            var userdepartment = loginRequest.DepartmentID.ToString();
            if (userdetails != null)
            {
                 var dep=db.Department.Find(userdetails.DepartmentID);

                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, userdetails.Name),
                        new Claim(ClaimTypes.Name, userdetails.Name),
                        new Claim("Surname", userdetails.Surname),
                        new Claim("Department",dep.DepartmentName),
                        //new Claim("FullName", user.FullName),
                        //new Claim(ClaimTypes.Role, "Administrator"),
                    };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    //AllowRefresh = <bool>,
                    // Refreshing the authentication session should be allowed.

                    //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                    // The time at which the authentication ticket expires. A 
                    // value set here overrides the ExpireTimeSpan option of 
                    // CookieAuthenticationOptions set with AddCookie.

                    //IsPersistent = true,
                    // Whether the authentication session is persisted across 
                    // multiple requests. When used with cookies, controls
                    // whether the cookie's lifetime is absolute (matching the
                    // lifetime of the authentication ticket) or session-based.

                    //IssuedUtc = <DateTimeOffset>,
                    // The time at which the authentication ticket was issued.

                    //RedirectUri = <string>
                    // The full path or absolute URI to be used as an http 
                    // redirect response value.
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                              new ClaimsPrincipal(claimsIdentity),
                                              authProperties);
                return RedirectToAction("Index","Home");
            }
            else
            {
                TempData["message"] = "Email or password wrong";
                return RedirectToAction("Index", "Login");
                
            }
                 
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Login");
        }
    }
}
