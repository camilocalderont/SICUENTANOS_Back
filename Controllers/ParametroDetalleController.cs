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
    public class ParametroDetalleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ParametroDetalleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ParametroDetalle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParametroDetalle>>> GetParametroDetalle()
        {
          if (_context.ParametroDetalle == null)
          {
              return NotFound();
          }
            return await _context.ParametroDetalle.ToListAsync();
        }

        // GET: api/ParametroDetalle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParametroDetalle>> GetParametroDetalle(Guid id)
        {
          if (_context.ParametroDetalle == null)
          {
              return NotFound();
          }
            var parametroDetalle = await _context.ParametroDetalle.FindAsync(id);

            if (parametroDetalle == null)
            {
                return NotFound();
            }

            return parametroDetalle;
        }

        // PUT: api/ParametroDetalle/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParametroDetalle(Guid id, ParametroDetalle parametroDetalle)
        {
            if (id != parametroDetalle.Id)
            {
                return BadRequest();
            }

            _context.Entry(parametroDetalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParametroDetalleExists(id))
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

        // POST: api/ParametroDetalle
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ParametroDetalle>> PostParametroDetalle(ParametroDetalle parametroDetalle)
        {
          if (_context.ParametroDetalle == null)
          {
              return Problem("Entity set 'ApplicationDbContext.ParametroDetalle'  is null.");
          }
            _context.ParametroDetalle.Add(parametroDetalle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParametroDetalle", new { id = parametroDetalle.Id }, parametroDetalle);
        }

        // DELETE: api/ParametroDetalle/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParametroDetalle(Guid id)
        {
            if (_context.ParametroDetalle == null)
            {
                return NotFound();
            }
            var parametroDetalle = await _context.ParametroDetalle.FindAsync(id);
            if (parametroDetalle == null)
            {
                return NotFound();
            }

            _context.ParametroDetalle.Remove(parametroDetalle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParametroDetalleExists(Guid id)
        {
            return (_context.ParametroDetalle?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
