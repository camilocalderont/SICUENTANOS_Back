using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SICUENTANOS_Back.Models;
using SICUENTANOS_Back.Models.Administrador;

namespace SICUENTANOS_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ActividadController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Actividad
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actividad>>> GetActividad()
        {
          if (_context.Actividad == null)
          {
              return NotFound();
          }
            _context.Actividad.ToListAsync();
            
            return await _context.Actividad.ToListAsync();
        }

        // GET: api/Actividad/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Actividad>> GetActividad(Guid id)
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

            return actividad;
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

            _context.Entry(actividad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                 return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActividadExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

           
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
