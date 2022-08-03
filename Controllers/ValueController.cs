using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using p127Api.DAL;
using p127Api.DTOs;
using p127Api.DTOs.Phone;
using p127Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using p127Api.Models.Base;
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
        public async Task<IActionResult> Create(PhonePostDto phoneDto)
        {
            if (phoneDto is null) return NotFound();
            Phone phone = new Phone
            {
                Brand=phoneDto.Brand,
                Model = phoneDto.Model,
                Price = phoneDto.Price,
                Color = phoneDto.Color,
                Display=phoneDto.Display

            };
            await _context.Phones.AddAsync(phone);
            await _context.SaveChangesAsync();
            return StatusCode(201, new { id=phone.id,phone=phoneDto});
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0) return BadRequest();
            Phone phone = _context.Phones.FirstOrDefault(p => p.id == id);
            if (phone is null) return NotFound();
            PhoneGetDto phonedto = new PhoneGetDto { 
                id=phone.id,
                Brand = phone.Brand,
                Model = phone.Model,
                Color = phone.Color,
                Price = phone.Price,
                Display=phone.Display
            };
            if (phone is null) return NotFound();
            return Ok(phonedto);
        }
        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll(int page=1,string serarch=null)
        {
            var query= _context.Phones.AsQueryable();
            if (!string.IsNullOrEmpty(serarch))
            {
                query = query.Where(p => p.Brand.Contains(serarch));
            }
            PhoneListDto phoneListDtos = new PhoneListDto
            {
                PhoneListItemDtos = query.Select(p => new PhoneListItemDto { id = p.id, Brand = p.Brand, Model = p.Model, Color = p.Color, Price = p.Price }).Skip((page - 1) * 4).Take(4).ToList(),
                Totalcount = query.Where(p => p.Display == true).Count()
            };
            return Ok(phoneListDtos);
        }
        [HttpPut("updata/{id}")]
      public IActionResult Updata(int id,PhonePostDto PhoneDto)
        {
            if (id == 0) return BadRequest();
            Phone existed = _context.Phones.FirstOrDefault(p => p.id == id);
            if (existed is null) return NotFound();
            _context.Entry(existed).CurrentValues.SetValues(PhoneDto);
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
        public IActionResult Change(int id,bool Display)
        {
            if (id == 0) return BadRequest();
            Phone existed = _context.Phones.FirstOrDefault(p => p.id == id);
            if (existed is null) return NotFound();
            existed.Display = Display;
            _context.SaveChanges();
            return NoContent();

        }
    }
}
