using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SICUENTANOS_Back.Models;
using SICUENTANOS_Back.Models.Administrador;
using SICUENTANOS_Back.Services;

namespace SICUENTANOS_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IGenericService<Actividad> _service;

        public ActividadController(ApplicationDbContext context, IGenericService<Actividad> service)
        {
            _context = context;
            _service = service;
        }

        // GET: api/Actividad
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actividad>>> GetActividad()
        {
            if (!_service.ExistsAsync())
            {
                return NotFound();
            }
            return await _service.GetAsync();
        }

        // GET: api/Actividad/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Actividad>> GetActividad(Guid id)
        {
            if (!_service.ExistsAsync())
            {
                return NotFound();
            }

            var actividad = await _service.GetAsync(e=> e.Id == id,e=> e.OrderBy(e=>e.Id),"");
            //var actividad = await _context.Actividad.FindAsync(id);

            if (actividad.Count < 1)
            {
                return NotFound();
            }

            return actividad[0];
        }

        // PUT: api/Actividad/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActividad(Guid id, Actividad actividad)
        {
            if (id != actividad.Id)
            {
                return BadRequest();
            }
            bool updated = await _service.UpdateAsync(id, actividad);
            if(!updated){
                 return NotFound();
            }
            return Ok();            
        }

        // POST: api/Actividad
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Actividad>> PostActividad(Actividad actividad)
        {
          if (_context.Actividad == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Actividad'  is null.");
          }
            _context.Actividad.Add(actividad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActividad", new { id = actividad.Id }, actividad);
        }

        // DELETE: api/Actividad/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActividad(Guid id)
        {
            if (_context.Actividad == null)
            {
                return NotFound();
            }
            var actividad = await _context.Actividad.FindAsync(id);
            if (actividad == null)
            {
                return NotFound();
            }

            _context.Actividad.Remove(actividad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActividadExists(Guid id)
        {
            return (_context.Actividad?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
