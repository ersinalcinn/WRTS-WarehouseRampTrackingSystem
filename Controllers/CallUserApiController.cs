using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using wrts.Models;

namespace wrts.Controllers
{
    public class CallUserApiController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<User> users = new List<User>();
            var hhtc = new HttpClient();
            var response = await hhtc.GetAsync("https://localhost:44323/api/UserApi");
            string resString = await response.Content.ReadAsStringAsync();
            users = JsonConvert.DeserializeObject<List<User>>(resString);
            return View(users);
        }
        public async Task<IActionResult> Edit()
        {
            List<User> users = new List<User>();
            var hhtc = new HttpClient();
            var response = await hhtc.GetAsync("https://localhost:44323/api/UserApi");
            string resString = await response.Content.ReadAsStringAsync();
            users = JsonConvert.DeserializeObject<List<User>>(resString);
            return View(users);
        }
        public async Task<IActionResult> Delete()
        {
            List<User> users = new List<User>();
            var hhtc = new HttpClient();
            var response = await hhtc.GetAsync("https://localhost:44323/api/UserApi");
            string resString = await response.Content.ReadAsStringAsync();
            users = JsonConvert.DeserializeObject<List<User>>(resString);
            return View(users);
        }
        public async Task<IActionResult> Details()
        {
            List<User> users = new List<User>();
            var hhtc = new HttpClient();
            var response = await hhtc.GetAsync("https://localhost:44323/api/UserApi");
            string resString = await response.Content.ReadAsStringAsync();
            users = JsonConvert.DeserializeObject<List<User>>(resString);
            return View(users);
        }
    }
}
