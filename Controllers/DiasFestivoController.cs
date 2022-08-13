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
    public class DiasFestivoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly DiasFestivoService _service;

        public DiasFestivoController(ApplicationDbContext context, DiasFestivoService service)
        {
            _context = context;
            _service = service;
        }

        // GET: api/DiasFestivo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiasFestivo>>> GetDiasFestivo()
        {
            var dias = _service.GetDiasFestivo();
            if (dias.Result.Count == 0)
            {
                return NotFound();
            }
            return await dias; 
        }

        // GET: api/DiasFestivo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DiasFestivo>> GetDiasFestivo(Guid id)
        {          
            var diasFestivo = await _service.GetDiasFestivo(id);
            if (diasFestivo == null)
            {
                return NotFound();
            }

            return diasFestivo;
        }

        // PUT: api/DiasFestivo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiasFestivo(Guid id, DiasFestivo diasFestivo)
        {
            if (id != diasFestivo.Id)
            {
                return BadRequest();
            }

            //_context.Entry(diasFestivo).State = EntityState.Modified;

            try
            {
                //await _context.SaveChangesAsync();
                var dia = _service.PutDiasFestivo(id,diasFestivo);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiasFestivoExists(id))
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

        // POST: api/DiasFestivo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DiasFestivo>> PostDiasFestivo(DiasFestivo diasFestivo)
        {
          if (_context.DiasFestivo == null)
          {
              return Problem("Entity set 'ApplicationDbContext.DiasFestivo'  is null.");
          }
            _context.DiasFestivo.Add(diasFestivo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiasFestivo", new { id = diasFestivo.Id }, diasFestivo);
        }

        // DELETE: api/DiasFestivo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiasFestivo(Guid id)
        {
            if (_context.DiasFestivo == null)
            {
                return NotFound();
            }
            var diasFestivo = await _context.DiasFestivo.FindAsync(id);
            if (diasFestivo == null)
            {
                return NotFound();
            }

            _context.DiasFestivo.Remove(diasFestivo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DiasFestivoExists(Guid id)
        {
            return (_context.DiasFestivo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
