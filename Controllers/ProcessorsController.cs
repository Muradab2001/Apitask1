using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using p127Api.DAL;
using p127Api.DTOs.Processor;
using p127Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p127Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessorsController : ControllerBase
    {
        private readonly APIDbContext _context;

        public ProcessorsController(APIDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0) return BadRequest();
            Processor processor = _context.Processors.FirstOrDefault(p => p.id == id);
            if (processor is null) return NotFound();
            ProcessorGetDto dto = new ProcessorGetDto
            {
                Model=processor.Model,
                Id=processor.id,
                GHz=processor.GHz,
                Cores=processor.Cores
            };
            return Ok(dto);
        }
        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll(int page = 1, string serarch = null)
        {
            var query = _context.Processors.AsQueryable();
            if (!string.IsNullOrEmpty(serarch))
            {
                query = query.Where(p => p.Model.Contains(serarch));
            }
            ProcessorListDto processorListDto = new ProcessorListDto
            {
                ProcessorListItemDtos = query.Select(c => new ProcessorListItemDto { Id = c.id, Model = c.Model, Cores = c.Cores, GHz = c.GHz }).Skip((page - 1) * 4).Take(4).ToList(),
                Totalcount = query.Where(p => p.Cores>2).Count()
            };
            return Ok(processorListDto);
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(ProcessorPostDto processorPost)
        {
            if (processorPost is null) return NotFound();
            Processor processor = new Processor
            {
                Model = processorPost.Model,
                GHz = processorPost.GHz,
                Cores = processorPost.Cores,

            };
            await _context.Processors.AddAsync(processor);
            await _context.SaveChangesAsync();
            return StatusCode(201, new { id = processor.id, processor = processorPost });
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();
            Processor existed = _context.Processors.FirstOrDefault(p => p.id == id);
            if (existed is null) return NotFound();
            _context.Remove(existed);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPut("updata/{id}")]
        public IActionResult Updata(int id, ProcessorPostDto processordto)
        {
            if (id == 0) return BadRequest();
            Processor existed = _context.Processors.FirstOrDefault(p => p.id == id);
            if (existed is null) return NotFound();
            _context.Entry(existed).CurrentValues.SetValues(processordto);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
