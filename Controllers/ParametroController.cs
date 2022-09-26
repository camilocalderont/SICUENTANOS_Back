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
    public class ParametroController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ParametroController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Parametro
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parametro>>> GetParametro()
        {
          if (_context.Parametro == null)
          {
              return NotFound();
          }
            return await _context.Parametro.ToListAsync();
        }

        // GET: api/Parametro/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Parametro>> GetParametro(Guid id)
        {
          if (_context.Parametro == null)
          {
              return NotFound();
          }
            var parametro = await _context.Parametro.FindAsync(id);

            if (parametro == null)
            {
                return NotFound();
            }

            return parametro;
        }

        // PUT: api/Parametro/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParametro(Guid id, Parametro parametro)
        {
            if (id != parametro.Id)
            {
                return BadRequest();
            }

            _context.Entry(parametro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParametroExists(id))
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

        // POST: api/Parametro
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Parametro>> PostParametro(Parametro parametro)
        {
          if (_context.Parametro == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Parametro'  is null.");
          }
            _context.Parametro.Add(parametro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParametro", new { id = parametro.Id }, parametro);
        }

        // DELETE: api/Parametro/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParametro(Guid id)
        {
            if (_context.Parametro == null)
            {
                return NotFound();
            }
            var parametro = await _context.Parametro.FindAsync(id);
            if (parametro == null)
            {
                return NotFound();
            }

            _context.Parametro.Remove(parametro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParametroExists(Guid id)
        {
            return (_context.Parametro?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
