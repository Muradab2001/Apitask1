using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using p127Api.DAL;
using p127Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p127Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ValueController : ControllerBase
    {
        private readonly APIDbContext _context;

        public ValueController(APIDbContext context)
        {
           _context = context;
        }
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(Phone phone)
        {
            if (phone is null) return NotFound();
            _context.Phones.Add(phone);
            _context.SaveChanges();
            return StatusCode(201, phone);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0) return BadRequest();
            Phone phone = _context.Phones.FirstOrDefault(p => p.id == id);
            if (phone is null) return NotFound();
            return Ok(phone);
        }
        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            return Ok(_context.Phones.Where(c=>c.Display==true).ToList());
        }
        [HttpPut("updata/{id}")]
      public IActionResult Updata(int id,Phone phone)
        {
            if (id == 0) return BadRequest();
            Phone existed = _context.Phones.FirstOrDefault(p => p.id == id);
            if (existed is null) return NotFound();
            existed.Brand = phone.Brand;
            existed.Model = phone.Model;
            existed.Price = phone.Price;
            existed.Color = phone.Color;
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();
            Phone existed = _context.Phones.FirstOrDefault(p => p.id == id);
            if (existed is null) return NotFound();
            _context.Remove(existed);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPatch("change/{id}")]
        public IActionResult Change(int id,bool status)
        {
            if (id == 0) return BadRequest();
            Phone existed = _context.Phones.FirstOrDefault(p => p.id == id);
            if (existed is null) return NotFound();
            existed.Display = status;
            _context.SaveChanges();
            return NoContent();

        }
    }
}
