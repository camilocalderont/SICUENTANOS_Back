using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SICUENTANOS_Back.Models;
using SICUENTANOS_Back.Models.Administrador;

namespace SUCUENTANOS.controller 
{

    [Route("api/[controller]")]

    public class ModuloController : Controller
    {

        private readonly ApplicationDbContext _context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Modulo>>> GetModulo()
        {
          if (_context.Modulo == null)
          {
              return NotFound();
          }
            return await _context.Modulo.ToListAsync();
        }


    }
}