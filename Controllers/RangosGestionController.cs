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
    public class RangosGestionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RangosGestionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RangosGestion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RangosGestion>>> GetRangosGestion()
        {
          if (_context.RangosGestion == null)
          {
              return NotFound();
          }
            return await _context.RangosGestion.ToListAsync();
        }

        // GET: api/RangosGestion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RangosGestion>> GetRangosGestion(Guid id)
        {
          if (_context.RangosGestion == null)
          {
              return NotFound();
          }
            var rangosGestion = await _context.RangosGestion.FindAsync(id);

            if (rangosGestion == null)
            {
                return NotFound();
            }

            return rangosGestion;
        }

        // PUT: api/RangosGestion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRangosGestion(Guid id, RangosGestion rangosGestion)
        {
            if (id != rangosGestion.Id)
            {
                return BadRequest();
            }

            _context.Entry(rangosGestion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RangosGestionExists(id))
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

        // POST: api/RangosGestion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RangosGestion>> PostRangosGestion(RangosGestion rangosGestion)
        {
          if (_context.RangosGestion == null)
          {
              return Problem("Entity set 'ApplicationDbContext.RangosGestion'  is null.");
          }
            _context.RangosGestion.Add(rangosGestion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRangosGestion", new { id = rangosGestion.Id }, rangosGestion);
        }

        // DELETE: api/RangosGestion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRangosGestion(Guid id)
        {
            if (_context.RangosGestion == null)
            {
                return NotFound();
            }
            var rangosGestion = await _context.RangosGestion.FindAsync(id);
            if (rangosGestion == null)
            {
                return NotFound();
            }

            _context.RangosGestion.Remove(rangosGestion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RangosGestionExists(Guid id)
        {
            return (_context.RangosGestion?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
