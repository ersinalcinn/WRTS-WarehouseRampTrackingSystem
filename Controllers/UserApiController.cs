using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using wrts.Models;

namespace wrts.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        WRTSDbContext k = new WRTSDbContext();
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {

            var y = await k.User.ToListAsync();
            if (y is null)
            {
                return NoContent();
            }
            return y;

        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var y = await k.User.FirstOrDefaultAsync(x => x.UserID == id);
            if (y is null)
            {
                return NoContent();
            }
            return y;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] User y)
        {
            k.User.Add(y);
            k.SaveChanges();
            return Ok();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User y)
        {
            var y1 = k.User.FirstOrDefault(x => x.UserID == id);
            if (y1 is null)
            {
                return NotFound();
            }
            y1.Name = y.Name;
            y1.Surname = y.Surname;
            y1.Email = y.Email;
            y1.PasswordVerify = y.PasswordVerify;
            y1.DepartmentID = y.DepartmentID;
            k.Update(y1);
            k.SaveChanges();
            return Ok();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var y1 = k.User.FirstOrDefault(x => x.UserID == id);
            if (y1 is null)
            {
                return NotFound();
            }
            if (k.User.Any(x => x.UserID == id))
            {
                return NotFound("User");
            }
            k.User.Remove(y1);
            k.SaveChanges();
            return Ok();
        }
    }
}
