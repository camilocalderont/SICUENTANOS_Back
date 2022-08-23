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
    public class ModuloController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ModuloController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Modulo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Modulo>>> GetModulo()
        {
          if (_context.Modulo == null)
          {
              return NotFound();
          }
            return await _context.Modulo.ToListAsync();            
        }

        // GET: api/Modulo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Modulo>> GetModulo(Guid id)
        {
          if (_context.Modulo == null)
          {
              return NotFound();
          }
            var modulo = await _context.Modulo.FindAsync(id);

            if (modulo == null)
            {
                return NotFound();
            }

            return modulo;
        }

        // PUT: api/Modulo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModulo(Guid id, Modulo modulo)
        {
            if (id != modulo.Id)
            {
                return BadRequest();
            }

            _context.Entry(modulo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuloExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Modulo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Modulo>> PostModulo(Modulo modulo)
        {
          if (_context.Modulo == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Modulo'  is null.");
          }
            _context.Modulo.Add(modulo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModulo", new { id = modulo.Id }, modulo);
        }

        // DELETE: api/Modulo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModulo(Guid id)
        {
            if (_context.Modulo == null)
            {
                return NotFound();
            }
            var modulo = await _context.Modulo.FindAsync(id);
            if (modulo == null)
            {
                return NotFound();
            }

            _context.Modulo.Remove(modulo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModuloExists(Guid id)
        {
            return (_context.Modulo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
